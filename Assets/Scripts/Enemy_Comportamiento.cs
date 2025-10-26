using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class enemigo : MonoBehaviour
{
    public Camera Camara;
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
                int pos = Random.Range(-90, 90);
                transform.position = new Vector3(Random.Range(jugador.position.x + 30, pos), 0, Random.Range(jugador.position.z + 30, pos));
                modo++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime * 10);
                break;
        }
    }
}