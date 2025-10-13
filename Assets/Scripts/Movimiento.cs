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
    public float stamina = 25;
    public float staminaDism = 10f; //Disminucion de estamina
    public float staminaRegen = 5f; //Aumento de estamina

    //Movimiento de camara con mouse

    public Camera playerCamera;
    public float mouseSensitivity = 0.2f;
    private float xRotation = 0f;

    //Estamina

    public Slider staminaBar;


    public float velocidad = 15f;
    public CharacterController controller;
    public bool cooldawn_stamina = false;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        //Movimiento y correr
        /* rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;
        */
        //Resistencia
        stamina = maxStamina;

        //Movimiento de camara con mouse

        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/

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
        /*
        Vector2 mouseDelta = Mouse.current.delta.ReadValue() * mouseSensitivity;

        xRotation -= mouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 180f, 0f);
        */
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movimientoX + transform.forward * movimientoZ;

        correr();
        recarga_stamina();
        cooldawn();
        Vector3 mover = transform.right * movimientoX + transform.forward * movimientoZ;

        controller.Move(mover * velocidad * Time.deltaTime);


        /*
        transform.Rotate(Vector3.up * mouseDelta.x);
        */
        if (staminaBar != null)
        {
            staminaBar.value = stamina; 
        }
        
    }

    private void correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina >=1 && cooldawn_stamina == false) 
        {
            velocidad = 25f;
            stamina -= staminaDism * Time.fixedDeltaTime;
        }
        else
        {
            velocidad = 15f;

        }
    }

    private void recarga_stamina()
    {
        if (stamina < 25)
        {
            stamina += 2 * Time.fixedDeltaTime;
        }
    }

    private void cooldawn()
    {
        if (stamina <= 0)
        {
            cooldawn_stamina = true;

        }
        else
        {
            cooldawn_stamina = false;
        }

    }
    private void Move(Vector3 Direccion)
    {
        controller.SimpleMove(Direccion.normalized * velocidad);
    }

    /*
    void FixedUpdate()
    {

        bool wantsToRun = Keyboard.current.shiftKey.isPressed;

        if (wantsToRun && stamina > 0f)
        {
            stamina -= staminaDism * Time.fixedDeltaTime;
            if (stamina < 0f) stamina = 0f;
        }
        else
        {
            stamina += staminaRegen * Time.fixedDeltaTime;
            if (stamina > maxStamina) stamina = maxStamina;
        }

        bool canRun = wantsToRun && stamina > 0f;
        currentSpeed = canRun ? runSpeed : walkSpeed;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        if (move.magnitude > 1f) move.Normalize();

        rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);
    }*/

    /*public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }*/






    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame


}






