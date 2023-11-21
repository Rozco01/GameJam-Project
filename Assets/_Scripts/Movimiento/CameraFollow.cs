using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private Transform target;

   private void LateUpdate() {
     transform.position = target.position;

   }
}
