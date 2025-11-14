using System.Collections;
using TMPro;
using UnityEngine;

public class Pensamientos : MonoBehaviour
{
    [Header("Referencias UI")]
    public CanvasGroup thoughtCanvasGroup;
    public GameObject thoughtBox;
    public TextMeshProUGUI textoPensamiento;

    [Header("Opciones")]
    public float tiempoMin = 5f;
    public float tiempoMax = 12f;
    public float velocidadTipeo = 0.02f;
    public float fadeSpeed = 3f;
    public float tiempoVisible = 2.5f;

    [Header("Pensamientos")]
    [TextArea(2, 5)]
    public string[] pensamientos;

    bool activo = true;
    bool mostrando = false;

    Coroutine cicloPensamientos;

    void Start()
    {
        // Estado inicial oculto
        if (thoughtCanvasGroup != null) thoughtCanvasGroup.alpha = 0f;
        if (thoughtBox != null) thoughtBox.SetActive(false);

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

        // Preparar UI
        thoughtBox.SetActive(true);
        textoPensamiento.text = "";
        thoughtCanvasGroup.alpha = 0f;

        // Fade In
        while (thoughtCanvasGroup.alpha < 1f)
        {
            thoughtCanvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        // Efecto de tipeo
        foreach (char c in texto)
        {
            textoPensamiento.text += c;
            yield return new WaitForSeconds(velocidadTipeo);
        }

        // Permanencia en pantalla
        yield return new WaitForSeconds(tiempoVisible);

        // Fade out
        while (thoughtCanvasGroup.alpha > 0f)
        {
            thoughtCanvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        thoughtBox.SetActive(false);
        mostrando = false;

        // reactiva el ciclo principal
        cicloPensamientos = StartCoroutine(PensarCadaTanto());
    }

    // ---------------------------
    // Llamados desde dialogos
    // ---------------------------

    public void DesactivarPensamientos()
    {
        activo = false;

        if (cicloPensamientos != null)
            StopCoroutine(cicloPensamientos);

        StopAllCoroutines();

        thoughtCanvasGroup.alpha = 0f;
        thoughtBox.SetActive(false);
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
