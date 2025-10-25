﻿
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using System.Collections;
using UnityEngine.Rendering;


public class EnteCodigo : MonoBehaviour
{
    public Transform originEnte;
    public int enteNumero = 0;
    public Transform lookingCameraTransform;

    public Timer myTimer;

    private UtilidadDeEspejo espejo;

    private DetectorLibrosyVelas detector;

    // DIALOGO
    [SerializeField] private GameObject dialogoMark;
    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] linesDialogo;


    private bool isPlayerinRange;

    private float tiempoTexto = 0.05f;
    private bool dialogoStar;
    private int lineIndex;
    //Dialogo

    public GameObject entePrimero;

    [Range(0f, 1f)]
    public float sensitivity = 0.4f;
    Vector3 forwardVectorTowardsCamera;
    bool cameraLooking;
    float dotProductResult;


    private void Start()
    {
        espejo = GameObject.Find("Player").GetComponent<UtilidadDeEspejo>();
        detector = GameObject.Find("Player").GetComponent<DetectorLibrosyVelas>();
        dialogoMark.SetActive(false);

    }

    void Update()
    {
        CheckIfCameraIsLooking();

        if (isPlayerinRange && Input.GetKeyDown(KeyCode.E) && enteNumero == 1)
        {
            dialogoPanel.SetActive(true);

            myTimer.StartTimer();

            if (!dialogoStar)
            {
                StartDialogo();
            }

            else if (textoDialogo.text == linesDialogo[lineIndex])
            {
                NextDialogoLine();
                Time.timeScale = 1f;
                enteNumero += 1;
                entePrimero.SetActive(true);
                originEnte.gameObject.SetActive(false);
                dialogoPanel.SetActive(false);
                dialogoStar = false;
            }
        }
        else if (isPlayerinRange && Input.GetKeyDown(KeyCode.E) && enteNumero == 5)
        {
            dialogoPanel.SetActive(true);

            if (!dialogoStar)
            {
                StartDialogo2();
            }

            else if (textoDialogo.text == linesDialogo[lineIndex])
            {
                NextDialogoLine();
                Time.timeScale = 1f;
                originEnte.gameObject.SetActive(false);
                dialogoPanel.SetActive(false);
                dialogoStar = false;

                detector.libro.enabled = true;
                detector.vela.enabled = true;

                detector.numeroLibrosUI.enabled = true;
                detector.numeroVelasUI.enabled = true;
            }


        }

    }

    public void StartDialogo()
    {
        dialogoStar = true;
        dialogoPanel.SetActive(true);
        StartCoroutine(ShowLine());
        lineIndex = 0;
        Time.timeScale = 0f;
    }

    public void StartDialogo2()
    {
        dialogoStar = true;
        StartCoroutine(ShowLine());
        lineIndex = 1;
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

            dialogoPanel.SetActive(false);

        }
    }

    public void CheckIfCameraIsLooking()
    {

        forwardVectorTowardsCamera = (lookingCameraTransform.position - originEnte.position).normalized;
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
        if (espejo.usoEspejo == true && enteNumero == 0)
        {
            enteNumero += 1;
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

