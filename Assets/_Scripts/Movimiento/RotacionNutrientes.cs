using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionNutrientes : MonoBehaviour
{
    private ganchoNutrientes ganchoNutrientes;
    

    [SerializeField] private Transform objetivo;
    [SerializeField] private float velocidadRotacion = 2f;

    // Start is called before the first frame update
   private void Start()
    {
       ganchoNutrientes = FindObjectOfType<ganchoNutrientes>();

   
     
       
    }

    // Update is called once per frame
  private  void Update()
    {

       if (ganchoNutrientes.hit.collider == gameObject.GetComponent<Collider2D>())
        {
            // Permitir la rotación del nutriente enganchado

                

            // Puedes agregar aquí la lógica para girar el nutriente
            
           Vector3 dir = objetivo.position - transform.position;
         float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotacion = Quaternion.AngleAxis(angulo, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);


            //si gira completo 2 veces destruir
           if (transform.rotation.z >= 0.7f)
          {
               //desabilitar
               gameObject.SetActive(false);
               Debug.Log("Nutrientes Conseguidos");
               ganchoNutrientes.line.enabled = false;
               ganchoNutrientes.isGrappling = false;
            }
        }    
        else
        {
           
            //No permitir la rotación del nutriente enganchado

            Quaternion rotacion = Quaternion.AngleAxis(0, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);

            ganchoNutrientes.isGrappling = false;

        



                
        }
        
        ganchoNutrientes.isGrappling = false;
      
    }

}



    

