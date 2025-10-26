using UnityEngine;

public class Visualizar_enemigo : MonoBehaviour
{
    public Camera camara;
    int capa_enemy;
    public float cronometro;
    private int modo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        capa_enemy = LayerMask.NameToLayer("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
        {
            modo = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (modo)
        {
            case 0:
                
                camara.cullingMask |= (1 << capa_enemy);
                Debug.Log("Enemigo visible");
                break;
            case 1:
                camara.cullingMask &= ~(1 << capa_enemy);
                Debug.Log("Enemigo invisible");
                break;

        }
        
    }

}
