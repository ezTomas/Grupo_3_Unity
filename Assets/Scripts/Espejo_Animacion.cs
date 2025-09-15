using UnityEngine;
using UnityEngine.InputSystem;

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
    private float temporizadorEspejo = 0f;
    private float tiempoLimiteEspejo = 3f;

    private float temporizadorJumpScare = 2f;


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
            activadoJumpScare = true;
            espejo1.localPosition = newPositionEspejo1;
            espejo1.localRotation = Quaternion.Euler(newRotationEspejo1);

        }
        else
        {
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;
            activadoJumpScare = false;
        }

        if (activadoJumpScare)
        {
            if (temporizadorEspejo >= tiempoLimiteEspejo)
            {
                negro.SetActive(true);
            }

            temporizadorEspejo += Time.deltaTime;

        }
        
    }
}