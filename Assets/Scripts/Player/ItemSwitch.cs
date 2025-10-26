using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemSwitch : MonoBehaviour
{
    public GameObject Espejo;
    public GameObject Celular;

    private GameObject itemActual;

    [SerializeField] private Image espejo;
    [SerializeField] private Image celular;
    [SerializeField] private Image mouseEspejo;
    [SerializeField] private Image mouseCelular;

    private Color color = new Color(0.4f, 0.4f, 0.4f);

    //Sirve para elegir que objeto mostrar al iniciar "1 = Espejo, 2 = Celular"
    public int startIndex = 2;
    public bool seleccionado;

    void Start()
    {
        celular.color = color;
        espejo.color = color;

        mouseCelular.enabled = false;
        mouseEspejo.enabled = false;

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
            espejo.color = Color.white;
            celular.color = color;

            mouseCelular.enabled = false;
            mouseEspejo.enabled = true;

        }
            
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SelectItem(2);
            seleccionado = false;
            celular.color = Color.white;
            espejo.color = color;

            mouseCelular.enabled = true;
            mouseEspejo.enabled = false;

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