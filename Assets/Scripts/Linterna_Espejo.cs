using UnityEngine;
using UnityEngine.InputSystem;

public class Linterna_Espejo : MonoBehaviour
{
    public Light luzLinterna;
    public bool linternaActiva;

    private UtilidadDeEspejo utilidadDeEspejo;
    private ItemSwitch estaSeleccionado;


    private void Start()
    {
        utilidadDeEspejo = GetComponent<UtilidadDeEspejo>();
        estaSeleccionado = GetComponent<ItemSwitch>();
        luzLinterna.enabled = false;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed && utilidadDeEspejo.usoLinterna == true && estaSeleccionado.seleccionado == true)
        {
            luzLinterna.enabled = true;

        }
        else
        {
            luzLinterna.enabled = false;
        }

    }
}
