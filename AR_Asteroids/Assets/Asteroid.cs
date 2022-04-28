using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Asteroid : MonoBehaviour
{
    
    public Rigidbody rb;

    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;
    Vector3 tempPos;
    Collider asteroidCollider;
    
    void Start()
    {
    
    }

   private void OnTriggerEnter(Collider other) {
       
       if(other.gameObject.tag == "wall") {
            tempPos = new Vector3(-transform.position.x ,-transform.position.y,-transform.position.z );
            transform.position = tempPos; 
       }
    
    }
  
    public void SetTrajectory (Vector3 direction){
        rb.AddForce(direction * this.speed);
    }

    public void Destroy(){
        Destroy(this.gameObject, this.maxLifeTime);

    }

}
