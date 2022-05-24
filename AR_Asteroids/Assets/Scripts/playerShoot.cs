using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerShoot : MonoBehaviour {

	public Button playerShootButton;
	public Camera fpsCamera;
	public AudioSource laserSound;

	// Use this for initialization
	void Start () {

		//playerShootButton.onClick.AddListener (onShoot);
		laserSound = GameObject.Find("playerShootButton").GetComponent<AudioSource>();
		
	}
	
	public void onShoot()
	{
		laserSound.Play();
		RaycastHit hit;
		if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hit)) 
		{
			
			Asteroid target = hit.transform.GetComponent<Asteroid> ();

			if (target != null) 
			{
				target.hitCounter++;
				Debug.Log(target.hitCounter);
				target.takeDamage();
				
			}

			
		}

		
	}
}