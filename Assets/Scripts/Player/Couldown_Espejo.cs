using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Couldown_Espejo : MonoBehaviour
{
    public GameObject negro;
    [SerializeField] private TextMeshPro tiempo;

    private bool activadoJumpScare = false;
    public float temporizadorEspejo = 0f;
    private float tiempoLimiteEspejo = 20f;

    public float temporizadorJumpScare = 0f;
    private float limiteJumpScare = 2f;

    public float couldownEspejo = 25f;
    public bool couldown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        tiempo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo.text = couldownEspejo.ToString("F1", CultureInfo.InvariantCulture);
        if (couldown)
        {
            couldownEspejo -= Time.deltaTime;
            tiempo.enabled = true;


            if (couldownEspejo <= 0f)
            {
                couldown = false;
                couldownEspejo = 30f;
                tiempo.enabled = false;
            }
        }
        if (!couldown && Mouse.current.rightButton.isPressed)
        {
            temporizadorEspejo += Time.deltaTime;
        }
        else if (!couldown && Mouse.current.leftButton.isPressed)
        {
            temporizadorEspejo += Time.deltaTime;
        }
            else
        {
            if (!activadoJumpScare)
            {
                temporizadorEspejo = 0f;
            }
        }

        if (temporizadorEspejo >= tiempoLimiteEspejo && !activadoJumpScare && !couldown)
        {
            activadoJumpScare = true;
            negro.SetActive(true);
            temporizadorJumpScare = 0f;
            couldown = true;
        }


        if (activadoJumpScare)
        {
            temporizadorJumpScare += Time.deltaTime;

            if (temporizadorJumpScare >= limiteJumpScare)
            {
                negro.SetActive(false);
                activadoJumpScare = false;
                temporizadorEspejo = 0f;
            }
        }
    }
}
    

