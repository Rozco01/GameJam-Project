using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puntos : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    private ButtonMashingGameController buttonMashingGameController;
    public int puntosBattle;
    // Start is called before the first frame update

    
    void Start()
    {

        buttonMashingGameController = FindObjectOfType<ButtonMashingGameController>();





    }

    void Awake(){
    {
        DontDestroyOnLoad(this.gameObject);
         PlayerPrefs.SetInt("puntosBattle", 0);
    }
     
    
}


    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.HasKey("puntosBattle"))
        {
            puntosBattle = PlayerPrefs.GetInt("puntosBattle");
            puntos.text = "Puntos: "+ puntosBattle.ToString();

            PlayerPrefs.SetInt("puntosNivel1", puntosBattle);
             PlayerPrefs.Save();
        }
        else
        {
            puntosBattle = 0; // O cualquier valor predeterminado
        }


    }


}
