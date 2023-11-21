using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionGrap : MonoBehaviour
{
      public string etiquetaColliderB; // Etiqueta del collider que quieres ignorar
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag(etiquetaColliderB).GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
