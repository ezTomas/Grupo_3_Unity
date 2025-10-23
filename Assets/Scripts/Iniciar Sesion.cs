using UnityEngine;

public class IniciarSesion : MonoBehaviour
{
    private float tiempoDeJuego;
    private int tiempoEntero;

    void Start()
    {
        Metricas.Instance.IniciarSesion("Juan Pablo");


    }

    // Update is called once per frame
    void Update()
    {

        tiempoDeJuego = Time.unscaledDeltaTime;

        Debug.Log(tiempoDeJuego);

        Metricas.Instance.RegistrarEvento("Tiempo de Juego", tiempoDeJuego);
        
    }
}
