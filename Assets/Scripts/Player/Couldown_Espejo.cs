using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Couldown_Espejo : MonoBehaviour
{
    [SerializeField] private Image jumpScare;
    [SerializeField] private TextMeshPro tiempo;
    [SerializeField] private AudioClip jumpSound;

    private bool activadoJumpScare = false;
    public float temporizadorEspejo = 0f;
    private float tiempoLimiteEspejo = 10f;

    public float temporizadorJumpScare = 0f;
    private float limiteJumpScare = 2f;

    public float couldownEspejo = 8f;
    public bool couldown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpScare.enabled = false;
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
                couldownEspejo = 8f;
                tiempo.enabled = false;
            }
        }
        if (!couldown && Mouse.current.rightButton.isPressed && temporizadorEspejo >= 0)
        {
            temporizadorEspejo += Time.deltaTime;
        }

        else
        {
            if (!activadoJumpScare && temporizadorEspejo >= 1)
            {
                temporizadorEspejo -= Time.deltaTime / 2;
            }
        }

        if (temporizadorEspejo >= tiempoLimiteEspejo && !activadoJumpScare && !couldown)
        {
            activadoJumpScare = true;
            temporizadorJumpScare = 0f;
            couldown = true;
        }


        if (activadoJumpScare)
        {
            AudioController.instance.EjecutarSonido(jumpSound);
            jumpScare.enabled = true;
            temporizadorJumpScare += Time.deltaTime;

            if (temporizadorJumpScare >= limiteJumpScare)
            {
                activadoJumpScare = false;
                temporizadorEspejo = 0f;
                jumpScare.enabled = false;
            }
        }
    }
}
    

