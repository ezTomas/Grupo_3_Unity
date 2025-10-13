using Unity.Mathematics;
using UnityEngine;

public class Movimiento_Camara : MonoBehaviour
{
    public float sensibilidad = 10f;
    float Rotacionx = 0f;
    public Transform Jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        Rotacionx -= MouseY;
        Rotacionx = math.clamp(Rotacionx, -45f, 45f);

        transform.localRotation = Quaternion.Euler(Rotacionx, 0f,0f);
        Jugador.Rotate(Vector3.up * MouseX);

    }
}
