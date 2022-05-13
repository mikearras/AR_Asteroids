using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public float trajectoryVariance = 5.0f; 
    public int spawnAmount = 100;
    public float spawnDistance = 15;
   
    void Start()
    {
        
        StartCoroutine(Spawn());
       
    }

    private IEnumerator Spawn(){

        for(int i = 0; i < this.spawnAmount; i++){
            //This section allows the incoming asteroids to spawn on the edge of 
            //an invisible sphere that surrounds the player.  The size of the sphere is 
            //determined by spawnDistance
            Vector3 orientation = new Vector3 (1,1,1);
            Vector3 spawnDirection = Random.insideUnitSphere.normalized * this.spawnDistance;

            //Prevent spawning below the horizon line
            if(spawnDirection.y < 0){
                
                spawnDirection.y *= -1;

            }
            else if(spawnDirection.y < 5){
                    spawnDirection.y  += 5;
            }

            //No asteroids should come from behind the player
            if(spawnDirection.z < 0){
                spawnDirection.z *= -1;
            }
            else if(spawnDirection.z < 5){
                    spawnDirection.z  += 5;
            }
        

            

            //this section establish spawn location
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, orientation);
            yield return new WaitForSeconds(Random.Range(2,10));
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.SetTrajectory(rotation * -spawnDirection);
            

        }
       

    }

    

}
