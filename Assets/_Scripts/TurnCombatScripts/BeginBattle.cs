using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BeginBattel : MonoBehaviour
{

    public int valor;
     
    private GrappleHook grappelHook;
    public string scene;
  
   
    // Start is called before the first frame update
    void Start()
    {
      
        grappelHook = FindObjectOfType<GrappleHook>();
        valor = 0;
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (grappelHook != null && grappelHook.batalla == true)
        {
            Invoke("ChangeScene", 1f);
            grappelHook.batalla = false;
            
           
        
        
    }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }

     private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "enemy")
        {
            valor = 1;
            PlayerPrefs.SetInt("valor", valor);
            PlayerPrefs.Save();
        } else if (other.gameObject.tag == "enemy2")
        {
            valor = 2;
            PlayerPrefs.SetInt("valor", valor);
            PlayerPrefs.Save();
        }
    }

   


    
}

