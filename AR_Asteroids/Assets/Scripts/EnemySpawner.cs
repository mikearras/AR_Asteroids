using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy1;
    public Camera ARCamera;

    public float trajectoryVariance = 5.0f; 
    public int spawnAmount = 10;
    public float spawnDistance = 20;
    public int enemyCount;
   
    void Start()
    {
        spawnDistance = Random.Range(20, 35);
        StartCoroutine(Spawn());
       
    }
    
    //The following code was written based from Mike's Asteroid Spawner script. The code structure is credited to Mike Arras.
    private IEnumerator Spawn(){

        while (enemyCount < 12){
            Vector3 spawnDirection = Random.insideUnitSphere.normalized * this.spawnDistance;
            if (spawnDirection.y < 0) {
                spawnDirection.y *= -1;
            } else if (spawnDirection.y < 5) {
                spawnDirection.y += 5;
            }

            if (spawnDirection.z < 0) {
                spawnDirection.z *= -1;
            } else if (spawnDirection.z < 5) {
                spawnDirection.z += 5;
            }
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            Enemy enemy_ = Instantiate(enemy1, spawnPoint, Quaternion.identity);
            enemy_.ARCamera = ARCamera;
            yield return new WaitForSeconds(Random.Range(5,20));
            enemyCount += 1;
        }

    }

    

}
