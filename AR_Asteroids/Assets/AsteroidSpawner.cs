using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public int xPos;
    public int yPos;
    public int zPos;

    public float trajectoryVariance = 15.0f; 
    public int spawnAmount = 20;
    public float spawnDistance = 6;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn(){
        for(int i = 0; i < this.spawnAmount; i++){
            xPos = Random.Range(-2, 2);
            yPos = Random.Range(0, 2);
            zPos = Random.Range(-2, 2); 
            // Vector3 spawnDirection = Random.insideUnitSphere.normalized * this.spawnDistance;
            //Vector3 spawnPoint = this.transform.position + spawnDirection;
            //float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            //Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Asteroid asteroid = Instantiate(this.asteroidPrefab, new Vector3(xPos,yPos, zPos), Quaternion.identity);
            asteroid.Destroy();
            //asteroid.SetTrajectory(rotation * -spawnDirection);
        }

    }

}
