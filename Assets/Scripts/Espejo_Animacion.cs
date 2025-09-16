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

    public GameObject negro;

    private bool activadoJumpScare = false;
    public float temporizadorEspejo = 0f;
    private float tiempoLimiteEspejo = 3f;

    public float temporizadorJumpScare = 0f;
    private float limiteJumpScare = 2f;

    private float couldownLimite = 0f;
    public float couldownEspejo = 5f;
    private bool couldown = false;


    void Start()
    {
        originalPositionEspejo1 = espejo1.localPosition;
        negro.SetActive(false);

    }

    void Update()
    {
        if (couldown)
        {
            couldownEspejo -= Time.deltaTime;
            if (couldownEspejo <= couldownLimite)
            {
                couldown = false;
                couldownEspejo = 0f;
            }
        }


        if (!couldown && Mouse.current.rightButton.isPressed)
        {
            espejo1.localPosition = newPositionEspejo1;
            espejo1.localRotation = Quaternion.Euler(newRotationEspejo1);
            temporizadorEspejo += Time.deltaTime;
        }
        else
        {
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;
            if (!activadoJumpScare)
            {
                temporizadorEspejo = 0f;
            }
                
        }

        if (temporizadorEspejo >= tiempoLimiteEspejo || activadoJumpScare == false)
        {
            activadoJumpScare = true;
            if (temporizadorEspejo >= tiempoLimiteEspejo)
            {
                negro.SetActive(true);
                temporizadorJumpScare += Time.deltaTime;
                temporizadorEspejo = 3f;
                couldown = true;
            }
            if (temporizadorJumpScare >= limiteJumpScare)
            {
                negro.SetActive(false);
                temporizadorJumpScare = 0f;
                activadoJumpScare = false;
                temporizadorEspejo = 0f;
                
            }

        }
        else
        {
            activadoJumpScare = false;
        }
        
    }
}