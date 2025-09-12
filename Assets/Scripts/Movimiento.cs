using UnityEngine;
using UnityEngine.InputSystem;



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

    void Awake()
    {
        //Movimiento y correr
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;

        //Resistencia
        stamina = maxStamina;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        if (move.magnitude > 1f) move.Normalize();

        rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
