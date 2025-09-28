using UnityEngine;
using UnityEngine.InputSystem;

public class Linterna_Espejo : MonoBehaviour
{
    public Light luzLinterna;
    public bool linternaActiva;

    private UtilidadDeEspejo utilidadDeEspejo;


    private void Start()
    {
        utilidadDeEspejo = GetComponent<UtilidadDeEspejo>();
        luzLinterna.enabled = false;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed && utilidadDeEspejo.usoLinterna == true)
        {
            linternaActiva = !linternaActiva;

            if (linternaActiva == true)
            {
                luzLinterna.enabled = true;
            }

            if (linternaActiva == false)
            {
                luzLinterna.enabled = false;
            }
        }

    }
}
