using UnityEngine;

public class Visualizar_enemigo : MonoBehaviour
{
    public Camera camara;
    int capa_enemy;
    public float cronometro_cambio;
    public float cronometro;
    private int modo;
    private int modo_cambio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        capa_enemy = LayerMask.NameToLayer("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        cronometro_cambio += 1 * Time.deltaTime;
        if (cronometro_cambio >= 10)
        {
            modo_cambio = Random.Range(0, 2);
            cronometro_cambio = 0;
        }
        switch (modo_cambio)
        {
            case 0:
                camara.cullingMask &= ~(1 << capa_enemy);
                Debug.Log("Enemigo Invisible");
                break;
            case 1:
                cronometro_cambio += 4;
                cronometro += 1 * Time.deltaTime;
                if (cronometro >= 2)
                {
                    //modo = Random.Range(0, 2);
                    cronometro = 0;
                }
                switch (modo)
                {
                    case 0:
                        camara.cullingMask |= (1 << capa_enemy);
                        
                        modo++;
                        break;
                    case 1:
                        camara.cullingMask &= ~(1 << capa_enemy);
                        
                        modo--;
                        break;
                }
                Debug.Log("Enemigo parpadeo");
                break;
        }
    }

}
