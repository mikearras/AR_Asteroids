using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerShoot : MonoBehaviour {

	public Button playerShootButton;									// Reference the UI shoot button
	public Camera fpsCamera;											// Reference the AR camera
	public float fireRate = 0.25f;										// How often can the player fire
	public float weaponRange = 150f;									// How far can the player fire
	public Transform weaponEnd;											// Reference to the UI player weapon

	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);	// How long the laser will be visible
	private AudioSource gunAudio;										// Reference the laser sound effect
	private LineRenderer laserLine;										// Reference the laser graphic
	private float nextFire;												// How long until the player is able to fire again

	// Initialization
	void Start () {
		// Get and store a reference to our LineRenderer component
		laserLine = GetComponent<LineRenderer>();

		// Get and store a reference to our AudioSource component
		gunAudio = GetComponent<AudioSource>();

		// Wait for player to press the shoot button
		playerShootButton.onClick.AddListener (onShoot);


	}


	void onShoot()
	{
		// Update the time when our player can fire next
		nextFire = Time.time + fireRate;

		// Start our ShotEffect coroutine to turn our laser line on and off
		StartCoroutine (ShotEffect());

		// Create a vector at the center of our camera's viewport
		Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

		// Declare a raycast hit to store information about what our raycast has hit
		RaycastHit hit;

		// Set the start position for our visual effect for our laser to the position of weaponEnd
		laserLine.SetPosition (0, weaponEnd.position);

		if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hit, weaponRange)) 
		{
			// Set the end position for our laser line 
			laserLine.SetPosition (1, hit.point);

			// Get a reference to the asteroid target
			Asteroid target = hit.transform.GetComponent<Asteroid>();
			Enemy enemyTarget = hit.transform.GetComponent<Enemy>();

			if (target != null) 
			{

				target.hitCounter++;
				target.takeDamage();

				
			}
			else if (enemyTarget != null)
			{	
				enemyTarget.takeDamage();
			}

			
		}
		else
		{
		 	// If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
		 	laserLine.SetPosition (1, rayOrigin + (fpsCamera.transform.forward * weaponRange));
		}
	}

	private IEnumerator ShotEffect() 
	{
		// Play the shooting sound effect
		gunAudio.Play ();

		// Turn on our line renderer
		laserLine.enabled = true;

		// Wait for .07 seconds
		yield return shotDuration;

		// Deactivate our line renderer after waiting
		laserLine.enabled = false;
	}
}