using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    private int valorGanar;
    private int puntosJudador = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("puntosNivel1", 0);
        // Puedes agregar código de inicialización aquí si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        valorGanar = PlayerPrefs.GetInt("puntosNivel1");

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "Oprime Espacio para crear puente";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (valorGanar >= 3)
                {
                    text.text = "Ganaste";
                    valorGanar = valorGanar - 3;
                    PlayerPrefs.SetInt("puntosNivel1", valorGanar);
                     PlayerPrefs.SetInt("puntosBattle", valorGanar);
                    PlayerPrefs.Save();
                    Debug.Log("Ganaste " + valorGanar);

                }
                else if (valorGanar < 3)
                {
                    text.text = "Numero de puntos insuficientes";
                    Debug.Log("Numero de puntos insuficientes" + valorGanar);




                }


            }
        }


    }

    // Este método se llama cuando el jugador sale del collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = ""; // Establece el texto en blanco cuando el jugador sale del collider
        }
    }
}
