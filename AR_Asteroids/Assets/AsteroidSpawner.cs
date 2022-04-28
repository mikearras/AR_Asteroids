using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    
    public float trajectoryVariance = 15.0f; 
    public int spawnAmount = 5;
    public float spawnDistance = 15;
   
    void Start()
    {
        
        Spawn();
       
    }

    private void Spawn(){
        for(int i = 0; i < this.spawnAmount; i++){
            Vector3 orientation = new Vector3 (1,1,1);
            Vector3 spawnDirection = Random.insideUnitSphere.normalized * this.spawnDistance;

            if(spawnDirection.y < 5 && spawnDirection.y > 0){
                
                spawnDirection.y += 5;
            }

            if(spawnDirection.y < 0){
                
                spawnDirection.y *= -1;
            }

            if(spawnDirection.z < 0){
                spawnDirection.z *= -1;
            }

            if(spawnDirection.z < 5){
                spawnDirection.z  += 5;
            }


            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, orientation);
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.SetTrajectory(rotation * -spawnDirection);
            

        }

    }

}
