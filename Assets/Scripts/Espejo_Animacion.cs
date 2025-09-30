using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class UtilidadDeEspejo : MonoBehaviour
{
    public Transform espejo1;
    [Header("Original Position")]
    public Vector3 originalPositionEspejo1;
    public Quaternion originalRotationEspejo1;

    private Couldown_Espejo couldown;
    [Header("Nueva posición y rotación Mirar Atras")]
    public Vector3 positionEspejoAtras;
    public Vector3 rotationEspejoAtras;
    [Header("Nueva posición y rotación Linterna")]
    public Vector3 positionEspejoLinterna;
    public Vector3 rotationEspejoLinterna;

    public bool usoLinterna;
    private bool dentroTrigger = false;

    void Start()
    {
        originalPositionEspejo1 = espejo1.localPosition;
        originalRotationEspejo1 = espejo1.localRotation;
        couldown = GetComponent<Couldown_Espejo>();
    }

    void Update()
    {
        if (dentroTrigger) return;

        if (!couldown.couldown && Mouse.current.rightButton.isPressed)
        {
            espejo1.localPosition = positionEspejoAtras;
            espejo1.localRotation = Quaternion.Euler(rotationEspejoAtras);
        }
        else
        {
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
            if (other.gameObject.CompareTag("Laberinto"))
            {
                dentroTrigger = true;
                usoLinterna = true;

                if (!couldown.couldown && Mouse.current.leftButton.isPressed)
                {
                    espejo1.localPosition = positionEspejoLinterna;
                    espejo1.localRotation = Quaternion.Euler(rotationEspejoLinterna);

                }
                else
                {
                    espejo1.localPosition = originalPositionEspejo1;
                    espejo1.localRotation = originalRotationEspejo1;
                    dentroTrigger = false;
                }            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Laberinto"))
        {
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;
            usoLinterna = false;
        }
    }
}

