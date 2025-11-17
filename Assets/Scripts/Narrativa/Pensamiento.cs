using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pensamientos : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private GameObject contorno;
    [SerializeField] private TMP_Text textoPensamiento;

    [Header("Opciones")]
    public float tiempoMin = 5f;
    public float tiempoMax = 12f;
    public float velocidadTipeo = 0.2f;
    public float tiempoVisible = 3f;

    [Header("Pensamientos")]
    [TextArea(2, 5)]
    public string[] pensamientos;

    bool activo = true;
    bool mostrando = false;

    Coroutine cicloPensamientos;

    void Start()
    {
        if (contorno != null) contorno.SetActive(false);

        cicloPensamientos = StartCoroutine(PensarCadaTanto());
    }

    IEnumerator PensarCadaTanto()
    {
        while (true)
        {
            if (activo && !mostrando && pensamientos.Length > 0)
            {
                yield return new WaitForSeconds(Random.Range(tiempoMin, tiempoMax));
                if (activo) MostrarPensamientoAleatorio();
            }
            yield return null;
        }
    }

    void MostrarPensamientoAleatorio()
    {
        if (!activo || pensamientos.Length == 0) return;

        int i = Random.Range(0, pensamientos.Length);

        if (cicloPensamientos != null)
            StopCoroutine(cicloPensamientos);

        StartCoroutine(MostrarPensamientoRoutine(pensamientos[i]));
    }

    IEnumerator MostrarPensamientoRoutine(string texto)
    {
        mostrando = true;

        contorno.SetActive(true);
        textoPensamiento.text = "";


        foreach (char c in texto)
        {
            textoPensamiento.text += c;
            yield return new WaitForSeconds(velocidadTipeo);
        }

        yield return new WaitForSeconds(tiempoVisible);

        contorno.SetActive(false);
        mostrando = false;


        cicloPensamientos = StartCoroutine(PensarCadaTanto());
    }

    public void DesactivarPensamientos()
    {
        activo = false;

        if (cicloPensamientos != null)
            StopCoroutine(cicloPensamientos);

        StopAllCoroutines();

        contorno.SetActive(false);
        mostrando = false;
    }

    public void ActivarPensamientos()
    {
        if (activo) return;

        activo = true;

        if (cicloPensamientos != null)
            StopCoroutine(cicloPensamientos);

        cicloPensamientos = StartCoroutine(PensarCadaTanto());
    }
}