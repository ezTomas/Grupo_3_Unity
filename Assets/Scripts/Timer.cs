using UnityEngine;

public class Timer : MonoBehaviour
{
    private float tiempoActual;
    private bool contadorActivo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (contadorActivo)
        {
            tiempoActual += Time.unscaledDeltaTime;
        }
    }

    public void StartTimer()
    {
        tiempoActual = 0;
        contadorActivo = true;
    }

    public void StopTimer()
    {
        contadorActivo = false;
    }

    public float GetTime()
    {
        return tiempoActual;
    }
}