using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteEnemigo : MonoBehaviour
{
    public Image imagen;
    public Sprite imagenValor1;
    public Sprite imagenValor2;

    // Supongamos que esta función es llamada cuando se cambia el valor
    public void ActualizarImagen(int valor)
    {
        if (valor == 1)
        {
            imagen.sprite = imagenValor1;
        }
        else if (valor == 2)
        {
            imagen.sprite = imagenValor2;
        }
        // Puedes agregar más condiciones según sea necesario para otros valores
    }
}
