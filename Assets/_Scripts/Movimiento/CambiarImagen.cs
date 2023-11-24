using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteEnemigo : MonoBehaviour
{
    public Image imagen;
    public Sprite imagenValor1;
    public Sprite imagenValor2;
    public Sprite imagenValor3;


    // Start is called before the first frame update
    void Start()
    {
        // Aquí se obtiene el valor guardado
        int valor = PlayerPrefs.GetInt("valor");

        // Aquí se cambia la imagen dependiendo del valor
        if (valor == 1)
        {
            imagen.sprite = imagenValor1;
            Debug.Log("valor 1");
        }
        else if (valor == 2)
        {
            imagen.sprite = imagenValor2;
            Debug.Log("valor 2");
        }
        else if (valor == 3)
        {
            imagen.sprite = imagenValor3;
            Debug.Log("valor 3");
        }
        else
        {
            Debug.Log("valor no encontrado");
            valor = 0;
        }
    }
 
    
}
