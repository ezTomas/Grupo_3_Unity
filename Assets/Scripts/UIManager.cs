using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI textoNumeros;

    private List<string> numerosEncontrados = new List<string>();

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;

        else 
            Destroy(gameObject);

        textoNumeros.text = "";
        textoNumeros.gameObject.SetActive(false);
    }

    public void MostrarNumero(string numero)
    {
        textoNumeros.text += numero + " ";

        if (!numerosEncontrados.Contains(numero))
        {
            numerosEncontrados.Add(numero);
        }

        textoNumeros.text = string.Join(" ", numerosEncontrados);

        if (!textoNumeros.gameObject.activeSelf)
            textoNumeros.gameObject.SetActive(true);
    }
}
