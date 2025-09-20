using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Build.Content;

public class enemigo : MonoBehaviour
{
    public Transform jugador;
    public static GameManagerDependencyInfo player;
    public int modo;
    public float cronometro;
    private float grado;
    private Quaternion angulo;
    public Transform objetos;
    private bool colision = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }
    public void Comportamiento_Enemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            modo = Random.Range(0, 3);
            cronometro = 0;
        }
        switch (modo)
        {
            case 0:
                break;
            case 1:

                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                int pos = Random.Range(-30, 30);
                transform.position = new Vector3(Random.Range(jugador.position.x + 10, pos), 0, Random.Range(jugador.position.z + 10, pos));
                colision = true;
                modo++;
                break;
                case 2:
                    colision = false;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break;
                
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (colision == true)
        {
            int pos = Random.Range(-30, 30);
            transform.position = new Vector3(Random.Range(jugador.position.x, pos), 0, Random.Range(jugador.position.z, pos));

            Debug.Log("oli");

            if (other.CompareTag("Objetos"))
            {
                colision = true;
            }
            else
            {
                colision = false;
            }

        }
        /*if (other.CompareTag("objetos") && colision)
        {
            activar = true;
            Debug.Log("estoy sufriendo v;");
        }*/

        /*
            if (other.CompareTag("objetos"))
        {
            int pos = Random.Range(-30, 30);
            transform.position = new Vector3(Random.Range(jugador.position.x, pos), 0, Random.Range(jugador.position.z, pos));
            Debug.Log("hola");
        }
        */

    }


}