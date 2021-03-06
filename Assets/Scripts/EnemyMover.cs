using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
	public float speed, maxSpeed, xAcc, yAcc;
	public float yDir, xDir;
	public float shotFrequency;
	float xVelocity, yVelocity;
	public float waitTime;
	public Rigidbody rb;
	public GameObject shot;
	public Transform EnemyShotSpawn;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * speed;
		xVelocity = rb.velocity.x;
	}

	void Update () {
		if (Random.Range (0, 100) < shotFrequency) {
			Instantiate (shot, EnemyShotSpawn.position, EnemyShotSpawn.rotation);
		}

		xVelocity += xAcc * xDir;
		yVelocity += yAcc * yDir;

		if (xVelocity >= maxSpeed || xVelocity < (maxSpeed*-1)) {
			xAcc *= -1;
		}
		if (yVelocity >= maxSpeed || yVelocity < (maxSpeed*-1)) {
			yAcc *= -1;
			//Instantiate (shot, EnemyShotSpawn.position, EnemyShotSpawn.rotation);
		}
		if (xVelocity != 0) {
			rb.velocity = transform.right * xVelocity;
		}
		if (yVelocity != 0) {
			rb.velocity = transform.up * yVelocity;
		}
	}
		
}

