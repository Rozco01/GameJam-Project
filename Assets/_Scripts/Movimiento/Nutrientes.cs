using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Nutrientes : MonoBehaviour
{
    //texto de los puntos de batalla

    private int puntos = 0;
    private TextMeshProUGUI Puntos_Batalla;
    // Start is called before the first frame update
    void Start()
    {

        Puntos_Batalla = GetComponent<TextMeshProUGUI>();

        puntos = PlayerPrefs.GetInt("PuntosBatalla");


    }

    // Update is called once per frame
    void Update()
    {
        if (Puntos_Batalla != null)
        {
            Puntos_Batalla.text = "Nutrientes: " + puntos.ToString();
        }
        else
        {
            Debug.LogWarning("El objeto de texto 'Puntos_Batalla' no está asignado.");
        }
    }
}
