using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    public Transform jugador;
    public float velocidad;
    public float rangoPersecucion;

    private void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= rangoPersecucion)
        {
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}

   

