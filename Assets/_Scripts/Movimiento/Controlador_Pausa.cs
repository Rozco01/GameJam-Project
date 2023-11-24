using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Pausa : MonoBehaviour
{
   
    private GrappleHook grappelHook;
    private bool juegoPausado = false;

    public  Rigidbody2D playerRigidbody;
    private movimienti movimiento;

    
    // Start is called before the first frame update
    void Start()
    {

        movimiento = FindObjectOfType<movimienti>();
        playerRigidbody = FindObjectOfType<Rigidbody2D>();
        grappelHook = FindObjectOfType<GrappleHook>();


    }


    public void PausarJuego()
    {
        juegoPausado = true;
        PausarObjetosConEtiqueta("Player");
        PausarObjetosConEtiqueta("enemy");
        PausarObjetosConEtiqueta("enemy2");
        movimiento.speed = 0;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        grappelHook.isGrappling = true;
         

    }

    public void ReanudarJuego()
    {
        juegoPausado = false;
        ReanudarObjetosConEtiqueta("Player");
        ReanudarObjetosConEtiquetaEnemigo("enemy");
        ReanudarObjetosConEtiquetaEnemigo("enemy2");
        movimiento.speed = 3;
        playerRigidbody.constraints = RigidbodyConstraints2D.None;
        grappelHook.isGrappling = false;
    }



    private void PausarObjetosConEtiqueta(string etiqueta)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(etiqueta);
        foreach (GameObject objeto in objetos)
        {
            objeto.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    private void ReanudarObjetosConEtiquetaEnemigo(string etiqueta)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(etiqueta);
        foreach (GameObject objeto in objetos)
        {
            objeto.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    private void ReanudarObjetosConEtiqueta(string etiqueta)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(etiqueta);
        foreach (GameObject objeto in objetos)
        {
            objeto.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    private void Awake()
    {
        if (Time.timeScale == 0f)
        {
            ReanudarJuego();
        }


    }

}
