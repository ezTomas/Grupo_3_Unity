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
    public float stamina = 35f;
    public float staminaDism = 1f; //Disminucion de estamina
    public float staminaRegen = 5f; //Aumento de estamina

    //Movimiento de camara con mouse

    public Camera playerCamera;
    public float mouseSensitivity = 0.2f;
    private float xRotation = 0f;

    //Estamina

    public Slider staminaBar;


    public float velocidad = 15f;
    public CharacterController controller;


    void Awake()
    {
        controller = GetComponent<CharacterController>();

        stamina = maxStamina;
        if (staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
            staminaBar.value = stamina;
        }



    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {

        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movimientoX + transform.forward * movimientoZ;

        correr();
        recarga_stamina();

        Vector3 mover = transform.right * movimientoX + transform.forward * movimientoZ;

        controller.Move(mover * velocidad * Time.deltaTime);

        if (staminaBar != null)
        {
            staminaBar.value = stamina;
        }

    }

    private void correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 0)
        {
            velocidad = 30f;
            stamina -= 0.7f * Time.fixedDeltaTime;
        }
        else
        {
            velocidad = 15f;

        }
    }

    private void recarga_stamina()
    {
        if (stamina < 35)
        {
            stamina += 0.2f * Time.fixedDeltaTime;
        }
    }
}






