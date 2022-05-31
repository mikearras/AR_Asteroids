using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager1 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public ParticleSystem explosion;
    public ParticleSystem enemyExplosion;
    private AudioSource explosionSound;
    List<AudioSource> sourceList = new List<AudioSource>();
    public AudioSource explosionSound1;
    public AudioSource explosionSound2;
    public AudioSource explosionSound3;
    public AudioSource explosionSound4;


    public void enemyHit(Enemy enemy)
    {

        this.score += 100;
        this.enemyExplosion.transform.position = enemy.transform.position;
        this.enemyExplosion.Play();
        sourceList.Add(explosionSound1);
        sourceList.Add(explosionSound2);
        sourceList.Add(explosionSound3);
        sourceList.Add(explosionSound4);
        int explosionSoundIndex = UnityEngine.Random.Range(0,4);
        sourceList[explosionSoundIndex].Play();

    }


    public void asteroidHit(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        sourceList.Add(explosionSound1);
        sourceList.Add(explosionSound2);
        sourceList.Add(explosionSound3);
        sourceList.Add(explosionSound4);
        int explosionSoundIndex = UnityEngine.Random.Range(0,4);

        sourceList[explosionSoundIndex].Play();



        if (asteroid.size == 1)
        {
            this.score += 25;
        }
        if (asteroid.size == .5)
        {
            this.score += 50;
        }

        if (asteroid.size == .25)
        {
            this.score += 100;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (score.ToString());
    }
}
