using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BeginBattel : MonoBehaviour
{
     
    private GrappleHook grappelHook;
    public string scene;
  
    // Start is called before the first frame update
    void Start()
    {
      
        grappelHook = FindObjectOfType<GrappleHook>();
      
       
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
}
