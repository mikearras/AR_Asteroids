using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
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

            Enemy enemy = Instantiate(this.enemyPrefab, new Vector3(xPos,yPos, zPos), Quaternion.identity);
            enemy.GetComponent<Renderer>().material.color = Color.red;
            enemy.Destroy();
        }

    }

}