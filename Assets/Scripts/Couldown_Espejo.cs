using UnityEngine;
using UnityEngine.InputSystem;

public class Couldown_Espejo : MonoBehaviour
{
    public GameObject negro;

    private bool activadoJumpScare = false;
    public float temporizadorEspejo = 0f;
    private float tiempoLimiteEspejo = 2f;

    public float temporizadorJumpScare = 0f;
    private float limiteJumpScare = 2f;

    private float couldownLimite = 0f;
    public float couldownEspejo = 30f;
    public bool couldown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        negro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (couldown)
        {
            couldownEspejo -= Time.deltaTime;
            if (couldownEspejo <= 0f)
            {
                couldown = false;
                couldownEspejo = 30f;
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
    

