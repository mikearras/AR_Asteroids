using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code has been adapted from tutorials

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.4f;
    public float rotation_damping = 4f;
    public Camera ARCamera;

    public GameObject fireBall;
    public Transform firePoint;

    public float fireRate;
    public float fireCount;

    private Vector3 targetPoint;

    public int enemyHealth  = 3; // take 3 shots to kill an enemy
    public Rigidbody _therigidbody;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        // enemy should look at the AR camera 
        var rotation = Quaternion.LookRotation(ARCamera.transform.position - transform.position);
        //does linear interpolation (curve fitting)
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_damping);
        
        targetPoint = ARCamera.transform.position;
        targetPoint.y = transform.position.y;
        if(Vector3.Distance(this.transform.position, targetPoint) < 20f && Vector3.Distance(this.transform.position, targetPoint) > 10f) {
            this.transform.LookAt(targetPoint);
            _therigidbody.velocity = transform.forward * speed;
        } else {
            _therigidbody.velocity = transform.forward * 0;
        }
        
        fireCount -= Time.deltaTime;
        if (fireCount <= 0) {
            fireCount = fireRate;
            Instantiate(fireBall, firePoint.position, firePoint.rotation);
        }

    }

    public void takeDamage() {
        enemyHealth--;
        if (enemyHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
