using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class UtilidadDeEspejo: MonoBehaviour
{
    public Transform espejo1;

    private Vector3 originalPositionEspejo1;
    private Quaternion originalRotationEspejo1;

    [Header("Nueva posición y rotación")]
    public Vector3 newPositionEspejo1;
    public Vector3 newRotationEspejo1;

    //Temporizador
    public GameObject negro;

    private bool activadoJumpScare;
    public float temporizadorEspejo = 0f;
    private float tiempoLimiteEspejo = 3f;

    private float temporizadorJumpScare = 0f;
    private float limiteJumpScare = 2f;


    private float couldownEspejo = 5f;


    void Start()
    {
        originalPositionEspejo1 = espejo1.localPosition;
        negro.SetActive(false);

    }

    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            espejo1.localPosition = newPositionEspejo1;
            espejo1.localRotation = Quaternion.Euler(newRotationEspejo1);
            temporizadorEspejo += Time.deltaTime;
        }
        else
        {
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;
            temporizadorEspejo = 0f;
        }

        if (temporizadorEspejo >= tiempoLimiteEspejo)
        {
            activadoJumpScare = true;
            if (temporizadorEspejo >= tiempoLimiteEspejo)
            {
                negro.SetActive(true);
                temporizadorJumpScare += Time.deltaTime;

            }

            if (temporizadorJumpScare >= limiteJumpScare)
            {
                negro.SetActive(false);
            }

            temporizadorEspejo += Time.deltaTime;

        }
        else
        {
            activadoJumpScare = false;
        }
        
    }
}