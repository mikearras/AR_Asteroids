using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float thrust = 10f;
    public float speed = 20.0f;
    public float maxLifeTime = 30.0f;
    
    private void Awake() {
        //_rigidbody = GetComponent<Rigidbody>();
        
    }
    void Start()
    {
       
       //_rigidbody.AddForce(0,0, thrust);
    }


  
    public void SetTrajectory (Vector2 direction){
        _rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    public void Destroy(){
        Destroy(this.gameObject, this.maxLifeTime);

    }

}
