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

    public bool isAttacked;
    private bool isChasing;
    public float distanceToChase = 10f;

    private Vector3 targetPoint;

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
        if (!isChasing) {
            if(Vector3.Distance(this.transform.position, ARCamera.transform.position) < distanceToChase) {
                isChasing = true;
            }
        } else {
            this.transform.LookAt(ARCamera.transform.position);
            if(Vector3.Distance(this.transform.position, ARCamera.transform.position) > distanceToChase) {
                isChasing = false;
            }
        }
        
        


        fireCount -= Time.deltaTime;
        if (fireCount <= 0) {
            fireCount = fireRate;
            Instantiate(fireBall, firePoint.position, firePoint.rotation);
        }


    }
}
