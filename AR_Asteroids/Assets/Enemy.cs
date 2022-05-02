using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float Distance;
    public UnityEngine.AI.NavMeshAgent agent;

    private Rigidbody _rigidbody;
    public float thrust = 10f;
    public float speed = 10.0f;
    public float maxLifeTime = 50.0f;

    //Attacking 
    // time between attacks and check if player is already attacked
    public float attackTime;
    bool isAttacked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetTrajectory (Vector2 direction){
        _rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    public void Destroy(){
        Destroy(this.gameObject, this.maxLifeTime);

    }
}