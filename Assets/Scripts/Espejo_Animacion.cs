using UnityEngine;
using UnityEngine.InputSystem;

public class ClickTransform : MonoBehaviour
{
    public Transform espejo1;
    public Transform espejo2;

    private Vector3 originalPositionEspejo1;
    private Quaternion originalRotationEspejo1;
    
    private Vector3 originalPositionEspejo2;
    private Quaternion originalRotationEspejo2;

    [Header("Nueva posición y rotación")]
    public Vector3 newPositionEspejo1;  
    public Vector3 newRotationEspejo1;

    public Vector3 newPositionEspejo2;
    public Vector3 newRotationEspejo2;

    void Start()
    {
        originalPositionEspejo1 = espejo1.localPosition;
        originalRotationEspejo1 = espejo1.localRotation;

        originalPositionEspejo2 = espejo2.localPosition;
        originalRotationEspejo2 = espejo2.localRotation;
    }

    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            Debug.Log("Click izquierdo detectado");
            espejo1.localPosition= newPositionEspejo1;
            espejo1.localRotation = Quaternion.Euler(newRotationEspejo1);

            espejo2.localPosition = newPositionEspejo2;
            espejo2.localRotation = Quaternion.Euler(newRotationEspejo2);
            Debug.Log("Click izquierdo detectado");
        }
        else
        {
            Debug.Log("Click derecho detectado");
            espejo1.localPosition = originalPositionEspejo1;
            espejo1.localRotation = originalRotationEspejo1;

            espejo2.localPosition = originalPositionEspejo2;
            espejo2.localRotation = originalRotationEspejo2;
            Debug.Log("Click derecho detectado");
        }
    }
}