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


    void Start()
    {
        originalPositionEspejo1 = espejo1.localPosition;
        couldown = GetComponent<Couldown_Espejo>();
    }

    void Update()
    {
        if (!couldown.couldown && Mouse.current.rightButton.isPressed)
        {
            espejo1.localPosition = positionEspejoAtras;
            espejo1.localRotation = Quaternion.Euler(rotationEspejoAtras);

        }

        else if (!couldown.couldown && Mouse.current.leftButton.isPressed)
        {
            espejo1.localPosition = positionEspejoLinterna;
            espejo1.localRotation = Quaternion.Euler(rotationEspejoLinterna);
        }

        else
        {
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;
        }
    }
}

