using UnityEngine;
using System.Collections.Generic;

public class CodigoEscape : MonoBehaviour
{
    [Header("Configuración del Código")]
    public string codigoCorrecto = "8364";
    public int intentosMaximos = 4;
    private int intentosFallidos = 0;

    [Header("Referencias")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject pantallaDerrota;
    [SerializeField] private GameObject pantallaVictoria;

    // 🔹 Este método lo llama PuertaTrigger
    public void IntentarAbrirPuerta()
    {
        string codigoJugador = string.Join("", uiManager.ObtenerNumeros());

        if (codigoJugador == codigoCorrecto)
        {
            AbrirPuerta();
        }
        else
        {
            intentosFallidos++;

            if (intentosFallidos >= intentosMaximos)
            {
                Perder();
            }
        }
    }

    private void AbrirPuerta()
    {
        if (puerta != null)
            puerta.SetActive(false); // Desaparece la puerta

        if (pantallaVictoria != null)
            pantallaVictoria.SetActive(true); // Pantalla victoria
    }

    private void Perder()
    {
        if (pantallaDerrota != null)
            pantallaDerrota.SetActive(true); // Pantalla derrota
    }
}