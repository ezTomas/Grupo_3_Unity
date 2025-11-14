using System.Collections;
using UnityEngine;
using TMPro;

public class IntroManager : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject introCanvas;     // Canvas de la intro
    public GameObject gameplay;        // Contenedor del juego
    public TextMeshProUGUI textoTMP;   // Texto de la intro

    [Header("Opciones")]
    public float velocidadTipeo = 0.03f;
    public CanvasGroup canvasGroup;    // Para fade in/out

    private string[] lineas =
    {
        "El protagonista, ha escuchado la historias de la Luz Mala toda su vida, pero nunca les dio importancia. Hasta que, una noche, durante una reunión con amigos, surge un reto: entrar al bosque y comprobar si la “luz mala” existe de verdad.\r\nCon celular en mano y la valentía que da el orgullo, se adentra solo entre los árboles. Al principio, todo parece normal. El canto de los grillos, el crujido de las ramas, el viento moviendo las hojas…\r\n Pero de pronto, una luz aparece entre la niebla. Pequeña, distante, casi hipnótica. Se mueve lentamente, como si lo invitara a seguirla.\r\nY así comienza su travesía.\r\n Una noche que parecía un simple reto se convertirá en una pesadilla donde nada es lo que parece. El bosque cambia, los caminos desaparecen, y el silencio esconde algo que lo observa desde la oscuridad.\r\nAhora, el jugador deberá explorar y descubrir la verdad detrás del mito antes de que la “luz mala” lo consuma también.\r\n"
    };

    private int indiceLinea = 0;
    private bool escribiendo = false;
    private bool lineaCompleta = false;

    void Start()
    {
        gameplay.SetActive(false);       // El juego está desactivado al inicio
        introCanvas.SetActive(true);     // La intro visible

        canvasGroup.alpha = 0f;
        StartCoroutine(FadeInIntro());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (escribiendo)
            {
                // Si está tipeando → mostrar todo inmediato
                MostrarLineaCompleta();
            }
            else
            {
                // Si la línea ya está completa → pasar a la siguiente
                SiguienteLinea();
            }
        }
    }

    IEnumerator FadeInIntro()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1.2f;
            canvasGroup.alpha = t;
            yield return null;
        }

        MostrarLineaActual();
    }

    void MostrarLineaActual()
    {
        textoTMP.text = "";
        StartCoroutine(EfectoTipeo(lineas[indiceLinea]));
    }

    IEnumerator EfectoTipeo(string linea)
    {
        escribiendo = true;
        lineaCompleta = false;

        textoTMP.text = "";

        foreach (char c in linea)
        {
            textoTMP.text += c;
            yield return new WaitForSeconds(velocidadTipeo);
        }

        escribiendo = false;
        lineaCompleta = true;
    }

    void MostrarLineaCompleta()
    {
        StopAllCoroutines();
        textoTMP.text = lineas[indiceLinea];
        escribiendo = false;
        lineaCompleta = true;
    }

    void SiguienteLinea()
    {
        if (!lineaCompleta) return;

        indiceLinea++;

        if (indiceLinea >= lineas.Length)
        {
            StartCoroutine(FinalizarIntro());
        }
        else
        {
            MostrarLineaActual();
        }
    }

    IEnumerator FinalizarIntro()
    {
        // Fade out
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * 1.2f;
            canvasGroup.alpha = t;
            yield return null;
        }

        introCanvas.SetActive(false);   // Oculta la intro
        gameplay.SetActive(true);       // Activa el juego
    }
}