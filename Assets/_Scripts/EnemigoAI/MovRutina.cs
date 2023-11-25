using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRutina : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float changeDirectionTime = 3f;
    private Vector2 currentDirection;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        StartCoroutine(ChangeDirection());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionTime);
            currentDirection = GetRandomDirection();
        }
    }

    private Vector2 GetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        return new Vector2(randomX, randomY).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Manejar la colisión aquí
    }
}

    

    

   

    


