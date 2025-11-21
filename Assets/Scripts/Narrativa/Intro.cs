using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Referencias")]
    [SerializeField] private Image introCanvas;     // Canvas de la intro       

    [SerializeField] private TMP_Text textoTMP;
    [SerializeField] private TMP_Text skip;

    [Header("Opciones")]
    public float velocidadTipeo = 0.03f;

    private string[] lineas =
    {
        "El protagonista, ha escuchado la historias de la Luz Mala toda su vida, pero nunca les dio importancia. Hasta que, una noche, durante una reunión con amigos, surge un reto: entrar al bosque y comprobar si la “luz mala” existe de verdad.\r\nCon celular en mano y la valentía que da el orgullo, se adentra solo entre los árboles. Al principio, todo parece normal. El canto de los grillos, el crujido de las ramas, el viento moviendo las hojas…\r\n Pero de pronto, una luz aparece entre la niebla. Pequeña, distante, casi hipnótica. Se mueve lentamente, como si lo invitara a seguirla.\r\nY así comienza su travesía.\r\n Una noche que parecía un simple reto se convertirá en una pesadilla donde nada es lo que parece. El bosque cambia, los caminos desaparecen, y el silencio esconde algo que lo observa desde la oscuridad.\r\nAhora, el jugador deberá explorar y descubrir la verdad detrás del mito antes de que la “luz mala” lo consuma también.\r\n"
    };

    private int indiceLinea = 0;
    private bool escribiendo = false;
    private bool lineaCompleta = false;

    void Start()
    {
        if (IntroController.introVista == false)
        {
            introCanvas.enabled = true;
            StartCoroutine(Introduccion());
            IntroController.introVista = true;
        }
        else
        {
            skip.gameObject.SetActive(false);
            introCanvas.enabled = false;

        }

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (escribiendo)
            {
                MostrarLineaCompleta();
            }
            else
            {
                SiguienteLinea();

            }
        }
    }

    IEnumerator Introduccion()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1.2f;
            yield return null;
        }

        MostrarLineaActual();

    }

    void MostrarLineaActual()
    {
        textoTMP.text = "";
        StartCoroutine(EfectoTipeo(lineas[indiceLinea]));
        Time.timeScale = 0f;
    }

    IEnumerator EfectoTipeo(string linea)
    {
        escribiendo = true;
        lineaCompleta = false;

        textoTMP.text = "";

        foreach (char c in linea)
        {
            textoTMP.text += c;
            yield return new WaitForSecondsRealtime(velocidadTipeo);
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
            Time.timeScale = 1f;
        }
        else
        {
            MostrarLineaActual();
        }
    }

    IEnumerator FinalizarIntro()
    {

        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * 1.2f;
            yield return null;
        }
        introCanvas.enabled = false;
        textoTMP.enabled = false;
        skip.enabled = false;
    }
}
