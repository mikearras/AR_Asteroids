using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Asteroid : MonoBehaviour
{
    
    public Rigidbody rb;

    public float maxSpeed = 20.0f;
    public float minSpeed = 5;
    public float maxLifeTime = 30.0f;
    public float size = 1.0f;
    public float large = 1.0f;
    public float small = .25f;
    public float medium = .50f;

    public float trajectoryVariance = 5.0f;

   public int hitCounter = 0;

    ///targetSize = asteroidSize.big;
    Vector3 tempPos;


    Collider asteroidCollider;

    void Start()
    {
        
         //Put spin on asteroids at random amounts on every axis
        
        Vector3 torque = new Vector3(Random.Range(0.0f, 10), Random.Range(0.0f, 10), Random.Range(0.0f, 10));
        rb.AddTorque(torque);
        this.transform.localScale = Vector3.one * size;
    }

    public void SetTrajectory(Vector3 direction)
    {
        //Give each asteroid a random speed between 
        rb.AddForce(direction * Random.Range(this.minSpeed, this.maxSpeed));
    }

    public void takeDamage()
    {

       
       if(this.size * .5f >= small)
       {
           splitAsteroid();
           splitAsteroid();
           
       }
       Destroy(this.gameObject);
       
    }

    public void splitAsteroid(){
        Vector3 orientation = new Vector3 (1,1,1);
        float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
        Vector3 position = this.transform.position;
        Quaternion rotation = Quaternion.AngleAxis(variance, orientation);
        position += Random.insideUnitSphere * .5f;
        Asteroid half = Instantiate(this, position, rotation);
        half.size = this.size * .5f;
        half.SetTrajectory(Random.insideUnitSphere.normalized);
    }

}
