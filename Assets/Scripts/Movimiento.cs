using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Movimiento : MonoBehaviour
{
    //Movimiento y correr

    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    private float currentSpeed;
    private Rigidbody rb;
    private Vector2 moveInput;

    //Resistencia

    public float maxStamina = 50f;
    public float stamina;
    public float staminaDism = 10f; //Disminucion de estamina
    public float staminaRegen = 5f; //Aumento de estamina

    //Movimiento de camara con mouse

    public Camera playerCamera;
    public float mouseSensitivity = 0.2f;
    private float xRotation = 0f;

    //Estamina

    public Slider staminaBar;

    void Awake()
    {
        //Movimiento y correr
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;

        //Resistencia
        stamina = maxStamina;

        //Movimiento de camara con mouse

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Inicio de la barra 

        if (staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
            staminaBar.value = stamina; 
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue() * mouseSensitivity;

        xRotation -= mouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseDelta.x);

        if (staminaBar != null)
        {
            staminaBar.value = stamina; 
        }
    }


    void FixedUpdate()
    {

        bool isRunning = Keyboard.current.shiftKey.isPressed && stamina > 0f;

        currentSpeed = isRunning ? runSpeed : walkSpeed;

        if (isRunning)
        {
            stamina -= staminaDism * Time.fixedDeltaTime;
            if (stamina < 0f) stamina = 0f;

        }

        else
        {
            stamina += staminaRegen * Time.fixedDeltaTime;
            if (stamina > maxStamina) stamina = maxStamina;
        }

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        if (move.magnitude > 1f) move.Normalize();

        rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
