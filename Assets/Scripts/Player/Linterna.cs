using UnityEngine;
using UnityEngine.InputSystem;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool linternaActiva;



    private void Start()
    {
        luzLinterna.enabled = false;


    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            linternaActiva = !linternaActiva;
            
            if (linternaActiva == true)
            {

                Metricas.Instance.RegistrarEvento("Uso Linterna", 1f);
                luzLinterna.enabled = true;


            }

            if (linternaActiva == false) 
            {
                luzLinterna.enabled = false;
            }
        }

    }
}






