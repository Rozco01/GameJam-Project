using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganchoNutrientes : MonoBehaviour {

    private RotacionNutrientes rotacionNutrientes;
   public  LineRenderer line;

    [SerializeField] LayerMask grapplableMask;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 20f;

   public  bool isGrappling = false;
    [HideInInspector] public bool retracting = false;

    Vector2 target;
    public RaycastHit2D hit;

    private void Start() {
        line = GetComponent<LineRenderer>();
        rotacionNutrientes = FindObjectOfType<RotacionNutrientes>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !isGrappling) {
            StartGrapple();
        }

        if (retracting) {
            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);

          

            line.SetPosition(0, transform.position);

            if (rotacionNutrientes.transform.rotation.z >= 1f) {
                retracting = false;
                isGrappling = false;
                line.enabled = false;

            }
        }
    }

    private void StartGrapple() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

       hit = Physics2D.Raycast(transform.position, direction, maxDistance, grapplableMask);

        if (hit.collider != null) {
          
            isGrappling = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;

            StartCoroutine(Grapple());
            
        }
    }

    IEnumerator Grapple() {
        float t = 0;
        float time = 10;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position); 

        Vector2 newPos;

        for (; t < time; t += grappleShootSpeed * Time.deltaTime) {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, newPos);
            yield return null;
        }
        
        line.SetPosition(1, target);
        retracting = true;
    }
}