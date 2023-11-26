using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    private int valorGanar = 0;
    private int puntosJudador = 0;

    // Start is called before the first frame update
    void Start()
    {
        puntosJudador = PlayerPrefs.GetInt("valorGanar");
        // Puedes agregar código de inicialización aquí si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        if (valorGanar == 3)
        {
            text.text = "Ganaste";
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "Oprime Espacio para crear puente";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (PlayerPrefs.GetInt("valor") == 0)
                {
                    // Puedes agregar código aquí si es necesario cuando el jugador no tiene puntos
                }
                else if (PlayerPrefs.GetInt("valor") > 0)
                {
                    valorGanar++;
                    puntosJudador--;
                    PlayerPrefs.SetInt("valorGanar", puntosJudador); 
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
