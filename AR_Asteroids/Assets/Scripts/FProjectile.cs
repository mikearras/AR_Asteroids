using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed, lifeTime;

    public Rigidbody _rigidbody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime; //makes the motion, frame independent

        if(lifeTime <= 0) {
            Destroy(gameObject);
        }
    }

    private void onTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
