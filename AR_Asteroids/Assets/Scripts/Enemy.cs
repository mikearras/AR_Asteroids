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

    //waiting in between moving back and forth
    private int leftMoveCounter = 0;
    private int rightMoveCounter = 0;
    private int MAX_MOVES = 5000;
    private float timeBetweenShots = 30.0f;
    private float MAX_FIREBALLS = 2;
    private float numFireballs = 0;

    private Vector3 targetPoint;

    public int enemyHealth  = 3; // take 3 shots to kill an enemy
    public Rigidbody _therigidbody;

    void Start()
    {
        speed = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // enemy should look at the AR camera 
        var rotation = Quaternion.LookRotation(ARCamera.transform.position + transform.position);
        //does linear interpolation (curve fitting)
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_damping);
        
        targetPoint = ARCamera.transform.position;
        this.transform.LookAt(targetPoint);
        _therigidbody.velocity = transform.forward * speed;
        //targetPoint.y = transform.position.y;
        if(Vector3.Distance(this.transform.position, targetPoint) < 20f && Vector3.Distance(this.transform.position, targetPoint) > 10f) {
            this.transform.LookAt(targetPoint);
            _therigidbody.velocity = transform.forward * speed;
        } else {
            if (rightMoveCounter < MAX_MOVES){
                _therigidbody.velocity = transform.right * speed;
                rightMoveCounter++;
            } else {
                if (leftMoveCounter != rightMoveCounter) {
                    _therigidbody.velocity = transform.right * -1 * speed;
                    leftMoveCounter++;
                } else {
                    rightMoveCounter = 0;
                    leftMoveCounter = 0;
                }
            }
        }
        
        fireCount -= Time.deltaTime;
        if (fireCount <= 0 && numFireballs < MAX_FIREBALLS) {
            fireCount = fireRate;
            Instantiate(fireBall, firePoint.position, firePoint.rotation);
            numFireballs++;
        } else {
            timeBetweenShots -= Time.deltaTime;
            if (timeBetweenShots < 0) {
                numFireballs = 0;
                timeBetweenShots = 30.0f;
            }
        }

    }

    public void takeDamage() {
        enemyHealth--;
        
        if (enemyHealth <= 0) {
           FindObjectOfType<GameManager1>().enemyHit(this);
           Destroy(this.gameObject);
        }
    }
}
