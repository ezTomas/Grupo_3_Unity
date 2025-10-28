
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;



public class EnteCodigo4 : MonoBehaviour
{
    public Transform enteTercero;
    private bool enteVisto = false;
    public Transform lookingCameraTransform;

    private UtilidadDeEspejo espejo;

    public GameObject enteOrigin;

    // DIALOGO
    [SerializeField] private GameObject dialogoMark;
    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] linesDialogo;


    private EnteCodigo enteNumeroOrigin;

    private Misiones misiones;

    private bool isPlayerinRange;

    private float tiempoTexto = 0.05f;
    private bool dialogoStar;
    private int lineIndex;
    //Dialogo

    public GameObject caminoVelas3;

    [Range(0f, 1f)]
    public float sensitivity = 0.4f;
    Vector3 forwardVectorTowardsCamera;
    bool cameraLooking;
    float dotProductResult;


    private void Start()
    {

        espejo = GameObject.Find("Player").GetComponent<UtilidadDeEspejo>();
        enteNumeroOrigin = GameObject.Find("Ente Principal").GetComponent<EnteCodigo>();

        enteTercero.gameObject.SetActive(false);

        dialogoMark.SetActive(false);

        misiones = GameObject.Find("Misiones").GetComponent<Misiones>();
    }

    void Update()
    {

        CheckIfCameraIsLooking();

        if (isPlayerinRange && Input.GetKeyDown(KeyCode.E) && enteNumeroOrigin.enteNumero == 4 && enteVisto == true)
        {
            if (!dialogoStar)
            {
                StartDialogo();
                caminoVelas3.SetActive(false);
            }

            else if (textoDialogo.text == linesDialogo[lineIndex])
            {
                Time.timeScale = 1f;
                NextDialogoLine();
                enteNumeroOrigin.enteNumero += 1;
                enteTercero.gameObject.SetActive(false);
                enteOrigin.SetActive(true);
                misiones.misione += 1;
            }

        }
    }

    public void StartDialogo()
    {
        dialogoStar = true;
        dialogoPanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
        Time.timeScale = 0f;
    }

    private IEnumerator ShowLine()
    {
        textoDialogo.text = string.Empty;

        foreach (char ch in linesDialogo[lineIndex])
        {
            textoDialogo.text += ch;
            yield return new WaitForSecondsRealtime(tiempoTexto);
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

        forwardVectorTowardsCamera = (lookingCameraTransform.position - enteTercero.position).normalized;
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
            dialogoMark.SetActive(true);

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

