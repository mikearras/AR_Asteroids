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

    public void asteroidHit(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

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
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (score.ToString());
    }
}
