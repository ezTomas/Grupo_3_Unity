using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Build.Content;

public class enemigo : MonoBehaviour
{
    public Transform jugador;
    public int modo;
    public float cronometro;
    private float grado;
    private Quaternion angulo;
    public Transform objetos;
    private bool colision = false;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (jugador == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                jugador = player.transform;
            }
            Debug.Log("h");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }
    public void Comportamiento_Enemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
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
                int pos = Random.Range(-90, 90);
                transform.position = new Vector3(Random.Range(jugador.position.x + 30, pos), 2, Random.Range(jugador.position.z + 30, pos));
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
            int pos = Random.Range(-90, 90);
            transform.position = new Vector3(Random.Range(jugador.position.x, pos), 2, Random.Range(jugador.position.z, pos));

            Debug.Log("oli");

            if (other.CompareTag("Objetos"))
            {
                colision = true;
            }
            else
            {
                colision = false;
            }

            if (other.CompareTag("objetos"))
            {
                int posx = Random.Range(-90, 90);
                transform.position = new Vector3(Random.Range(jugador.position.x, posx), 2, Random.Range(jugador.position.z, posx));
                Debug.Log("hola");
            }

        }
    }
}