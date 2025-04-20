// StarMovement.cs
   using UnityEngine;

   public class StarMovement : MonoBehaviour {
       public float scrollSpeed = 5f;
       void Update() {
           transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
           if (transform.localPosition.x < -1000) {
               transform.localPosition += Vector3.right * 2000;
           }
       }
   }