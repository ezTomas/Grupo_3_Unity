using UnityEngine;

public class IniciarSesion : MonoBehaviour
{
    private float tiempoDeJuego;
    private int tiempoEntero;

    void Start()
    {
        Metricas.Instance.IniciarSesion("Juan Pablo");

        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {

        tiempoDeJuego = Time.unscaledDeltaTime;

        Metricas.Instance.RegistrarEvento("Tiempo de Juego", tiempoDeJuego);
        
    }
}
