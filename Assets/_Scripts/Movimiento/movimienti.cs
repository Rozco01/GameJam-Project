using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimienti : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D rb;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       //mover al mersonaje con AWSD y hacer como si estuviera flotando
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal*speed, moveVertical*speed);
        rb.AddForce(movement);

      
   

}
}


