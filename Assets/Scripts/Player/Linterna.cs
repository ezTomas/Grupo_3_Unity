using UnityEngine;
using UnityEngine.InputSystem;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool linternaActiva;

    private EnteCodigo enteCodigo;

    private void Start()
    {
        luzLinterna.enabled = false;

        enteCodigo = GameObject.Find("Ente Principal").GetComponent<EnteCodigo>();
    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            linternaActiva = !linternaActiva;
            
            if (linternaActiva == true)
            {
                enteCodigo.myTimer.StopTimer();
                Metricas.Instance.RegistrarEvento("Completa Puzzle", enteCodigo.myTimer.GetTime());
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






