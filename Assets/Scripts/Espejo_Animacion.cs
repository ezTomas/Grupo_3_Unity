using UnityEngine;
using UnityEngine.InputSystem;

public class ClickTransform : MonoBehaviour
{
    public Transform objetoAModificar; 

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    [Header("Nueva posición y rotación")]
    public Vector3 newPosition;  
    public Vector3 newRotation;  

    void Start()
    {
        
        originalPosition = objetoAModificar.position;
        originalRotation = objetoAModificar.rotation;
    }

    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            Debug.Log("Click izquierdo detectado");
            objetoAModificar.position = newPosition;
            objetoAModificar.rotation = Quaternion.Euler(newRotation);
            Debug.Log("Click izquierdo detectado");
        }
        else
        {
            Debug.Log("Click derecho detectado");
            objetoAModificar.position = originalPosition;
            objetoAModificar.rotation = originalRotation;
            Debug.Log("Click derecho detectado");
        }
    }
}