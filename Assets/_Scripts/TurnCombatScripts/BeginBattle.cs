using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BeginBatte : MonoBehaviour
{
    private Controlador_Pausa controlador_Pausa;
    public int valor;
    private GrappleHook grappelHook;
    public string scene;



    //awake
   
    // Start is called before the first frame update
    void Start()
    {
        grappelHook = FindObjectOfType<GrappleHook>();
        controlador_Pausa = FindObjectOfType<Controlador_Pausa>();
        valor = 0;
    

        
    }

    // Update is called once per frame
    void Update()
    {
    
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy" )
        {
            
            valor = 1;
            PlayerPrefs.SetInt("valor", valor);
            PlayerPrefs.Save();


        }
        else if (other.gameObject.tag == "enemy2")
        {
            valor = 2;
            PlayerPrefs.SetInt("valor", valor);
            PlayerPrefs.Save();
        }else if (other.gameObject.tag == "enemy3")
        {
            valor = 3;
            PlayerPrefs.SetInt("valor", valor);
            PlayerPrefs.Save();
        }
        

        if( grappelHook != null && grappelHook.batalla == true && (other.gameObject.tag == "enemy" || other.gameObject.tag == "enemy2" || other.gameObject.tag == "enemy3"))
        {
            controlador_Pausa.PausarJuego();
            Invoke("ChangeScene", 1f);
            grappelHook.batalla = false;
            grappelHook.isGrappling = false;
            
           

        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }








}

