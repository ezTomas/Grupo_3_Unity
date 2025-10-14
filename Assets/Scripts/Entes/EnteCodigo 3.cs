using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using System.Collections;
using UnityEngine.Rendering;


public class EnteCodigo3 : MonoBehaviour
{
    public Transform enteSegundo;
    private bool enteVisto = false;
    public Transform lookingCameraTransform;

    private UtilidadDeEspejo espejo;

    // DIALOGO
    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] linesDialogo;

    private EnteCodigo enteNumeroOrigin;

    private bool isPlayerinRange;

    private float tiempoTexto = 0.05f;
    private bool dialogoStar;
    private int lineIndex;
    //Dialogo


    [Range(0f, 1f)]
    public float sensitivity = 0.4f;
    Vector3 forwardVectorTowardsCamera;
    bool cameraLooking;
    float dotProductResult;


    private void Start()
    {

        espejo = GameObject.Find("Player").GetComponent<UtilidadDeEspejo>();
        enteNumeroOrigin = GameObject.Find("Ente Principal").GetComponent<EnteCodigo>();

        enteSegundo.gameObject.SetActive(false);
    }

    void Update()
    {

        Debug.Log("enteNumeroOrigin.enteNumero: " + enteNumeroOrigin.enteNumero);


        CheckIfCameraIsLooking();

        if (isPlayerinRange && Input.GetButtonDown("Fire1") && enteNumeroOrigin.enteNumero == 3 && enteVisto == true)
        {
            if (!dialogoStar)
            {
                StartDialogo();
            }

            else if (textoDialogo.text == linesDialogo[lineIndex])
            {
                NextDialogoLine();
                enteNumeroOrigin.enteNumero += 1;
                enteSegundo.gameObject.SetActive(false);
            }

        }
    }

    public void StartDialogo()
    {
        dialogoStar = true;
        dialogoPanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        textoDialogo.text = string.Empty;

        foreach (char ch in linesDialogo[lineIndex])
        {
            textoDialogo.text += ch;
            yield return new WaitForSeconds(tiempoTexto);
        }
    }

    private void NextDialogoLine()
    {
        lineIndex++;
        if (lineIndex < linesDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogoStar = false;
            dialogoPanel.SetActive(false);
        }
    }

    public void CheckIfCameraIsLooking()
    {

        forwardVectorTowardsCamera = (lookingCameraTransform.position - enteSegundo.position).normalized;
        dotProductResult = Vector3.Dot(lookingCameraTransform.forward, forwardVectorTowardsCamera);
        if (cameraLooking)
        {
            if (dotProductResult > sensitivity)
            {
                cameraLooking = false;
            }
        }
        else
        {
            if (dotProductResult < -sensitivity)
            {
                cameraLooking = true;
                StartLooking();
            }
        }

    }

    void StartLooking()
    {
        if (espejo.usoEspejo == true && enteVisto == false)
        {
            enteVisto = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerinRange = false;
    }
}

