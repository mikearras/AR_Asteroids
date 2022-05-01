using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Asteroid : MonoBehaviour
{
    
    public Rigidbody rb;

    public float maxSpeed = 50.0f;
    public float minSpeed = 5;
    public float maxLifeTime = 30.0f;
    Vector3 tempPos;

   
    Collider asteroidCollider;
    
    void Start()
    {
        //Put spin on asteroids at random amounts on every axis
        Vector3 torque = new Vector3(Random.Range(0.0f, 10),Random.Range(0.0f, 10),Random.Range(0.0f, 10));
        rb.AddTorque(torque);
    }
  
    public void SetTrajectory (Vector3 direction){
        //Give each asteroid a random speed between 
        rb.AddForce(direction * Random.Range(this.minSpeed, this.maxSpeed));
    }

    public void Destroy(){
        Destroy(this.gameObject, this.maxLifeTime);

    }

}
