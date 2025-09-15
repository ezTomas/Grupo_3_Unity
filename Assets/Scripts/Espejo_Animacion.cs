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


    void Start()
    {
        originalPositionEspejo1 = espejo1.localPosition;

    }

    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            Debug.Log("Click izquierdo detectado");
            espejo1.localPosition= newPositionEspejo1;
            espejo1.localRotation = Quaternion.Euler(newRotationEspejo1);

        }
        else
        {
            Debug.Log("Click derecho detectado");
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;

        }
    }
}