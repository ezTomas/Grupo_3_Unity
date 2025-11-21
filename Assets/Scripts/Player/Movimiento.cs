using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Movimiento : MonoBehaviour
{
    //ente
    public bool puedeMoverse = true;

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


    //Estamina

    public Slider staminaBar;


    private Misiones misiones;

    public float velocidad = 15f;
    public CharacterController controller;

    public AudioSource walk;
    public AudioSource run;
    public Transform piso_madera;

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
        misiones = GameObject.Find("Misiones").GetComponent<Misiones>();
    }


    void Update()
    {
        if (!puedeMoverse) return;
        caminar();
        correr();
        recarga_stamina();

        if (staminaBar != null)
        {
            staminaBar.value = stamina;
        }
        sound_walk();
            
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Granja") && misiones.misione == 1)
        {
            misiones.misione += 1;
        }
    }

    private void caminar()
    {

        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");
        

        Vector3 mover = transform.right * movimientoX + transform.forward * movimientoZ;
        controller.Move(mover * velocidad * Time.deltaTime);
        

    }

    public void sound_walk()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
        {
            walk.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A))
        {
            walk.Stop();
        }
    }

}






