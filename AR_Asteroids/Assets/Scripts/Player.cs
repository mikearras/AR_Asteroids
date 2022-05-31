using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public HealthBar healthbar;
    public int health = 100;



    private void OnTriggerEnter(Collider other) {

        this.health -= 10;
        healthbar.setHealth(this.health);
      
    }
}
