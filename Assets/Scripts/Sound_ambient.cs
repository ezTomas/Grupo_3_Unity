using UnityEngine;

public class Sound_ambient : MonoBehaviour
{

    public int sonido;
    public float tiempo;
    public AudioSource sound_a;
    public AudioSource sound_b;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cambio_ambiente();
    }

    void cambio_ambiente()
    {
        tiempo += 1 * Time.deltaTime;
        if (tiempo > 10)
        {
            sonido = Random.Range(0, 3);
            tiempo = 0;
        }
        switch (sonido)
        {
            case 0:
                sound_b.Play();
                break;
            case 1:
                sound_a.Play();
                sound_b.Play();
                break;
            case 2:
                sound_b.Play();
                break;

        }
    }

}
