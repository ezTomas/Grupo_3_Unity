using UnityEngine;

public class moves : MonoBehaviour
{
    float velocidad = 25f;
    CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movementInput.z = 1;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementInput.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1;
        }
        else if (Input.GetKey(KeyCode.A)) 
        { 
            movementInput.x = -1;
        }
        Move(movementInput);
    }

    private void Move(Vector3 Direccion)
    {
        controller.SimpleMove(Direccion.normalized * velocidad);
    }
}
