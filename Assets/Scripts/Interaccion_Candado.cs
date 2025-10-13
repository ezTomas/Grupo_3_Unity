using UnityEngine;

public class Interaccion_Candado : MonoBehaviour
{

    public bool player_on = false;
    public GameObject Interfaz;
    public GameObject Interaccion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interfaz.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Escape)) 
        {
            Interfaz.SetActive(false);
            Interaccion.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interaccion.SetActive(true);
    }
}
