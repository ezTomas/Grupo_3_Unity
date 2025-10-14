using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class UtilidadDeEspejo : MonoBehaviour
{
    public Transform espejo1;
    public Camera camara;

    [Header("Original Position")]
    public Quaternion originalRotationEspejo1;

    private Couldown_Espejo couldown;
    [Header("Nueva posición y rotación Mirar Atras")]
    public Vector3 rotationEspejoAtras;
    [Header("Nueva posición y rotación Linterna")]
    public Vector3 rotationEspejoLinterna;

    public bool usoLinterna;
    private bool dentroTrigger = false;

    public bool usoEspejo;

    void Start()
    {
        originalRotationEspejo1 = espejo1.localRotation;
        couldown = GetComponent<Couldown_Espejo>();
        camara.gameObject.SetActive(false);
        usoEspejo = false;
    }

    void Update()
    {
        if (dentroTrigger) return;

        if (!couldown.couldown && Mouse.current.rightButton.isPressed)
        {
            espejo1.localRotation = Quaternion.Euler(rotationEspejoAtras);
            camara.gameObject.SetActive(true);
            usoEspejo = true;
        }
        else
        {
            espejo1.localRotation = originalRotationEspejo1;
            camara.gameObject.SetActive(false);
            usoEspejo = false;

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
                    espejo1.localRotation = Quaternion.Euler(rotationEspejoLinterna);

                }
                else
                {
                    espejo1.localRotation = originalRotationEspejo1;
                    dentroTrigger = false;
                }            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Laberinto"))
        {
            espejo1.localRotation = originalRotationEspejo1;
            usoLinterna = false;
        }
    }
}

