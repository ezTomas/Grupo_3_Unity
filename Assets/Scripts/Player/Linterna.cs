using UnityEngine;
using UnityEngine.InputSystem;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool linternaActiva;
    private Misiones misiones;


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
                luzLinterna.enabled = true;
                Metricas.Instance.RegistrarEvento("Uso Linterna", 1f);

            }

            if (linternaActiva == false) 
            {
                luzLinterna.enabled = false;
            }
        }

    }

      private void OnTriggerEnter(Collider other)
      {
           if (other.gameObject.CompareTag("Valla"))
           {
             if (misiones.misione <= 1)
                 {
                 misiones.misione += 1;
                  }
            

           }
        }



    }






