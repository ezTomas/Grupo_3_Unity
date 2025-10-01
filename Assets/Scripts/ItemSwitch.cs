using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSwitch : MonoBehaviour
{
    public GameObject Espejo;
    public GameObject Celular;

    private GameObject itemActual;

    //Sirve para elegir que objeto mostrar al iniciar "1 = Espejo, 2 = Celular"
    public int startIndex = 2;
    public bool seleccionado;

    void Start()
    {
        //Verifica el valor de startIndex para identificar el objeto que se mostrara al iniciar
        // sino mostrara el de valor 1
        if (startIndex == 1 || startIndex == 2)
        {
            SelectItem(startIndex);
        }
        else
        {
            SelectItem(0);
        }
     
        if (startIndex == 1)
        {
            seleccionado = true;
        }
    }

    void Update()
    {
        // Nuevo sistema de inputs  ---  "Input.GetKeyDown(KeyCode.Alpha1)" <- viejo
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SelectItem(1);
            seleccionado = true;
        }
            
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SelectItem(2);
            seleccionado = false;
        }
            
    }

    void SelectItem(int index)
    {
        // Apaga los objetos que no sean null
        if (Espejo != null)
        {
            Espejo.SetActive(false);
        }

        if (Celular != null)
        {
            Celular.SetActive(false);
        }

        // Eleje el objeto seleccionado evaluando quen o sea null para evitar errores
        if (index == 1 && Espejo != null)
        {
            itemActual = Espejo;
        }
        else if (index == 2 && Celular != null)
        {
            itemActual = Celular;
        }
        else
        {
            itemActual = null;
        }

        // Activa el objeto seleccionado
        if (itemActual != null)
        {
            itemActual.SetActive(true);
        }

    }
}