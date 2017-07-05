using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class Spawn : MonoBehaviour{
	public GameObject enemy;
	Transform spawner;
	public Vector3 spawnValues;
	public float waitTime;
	Boolean spawned;

	void Start () {
		spawned = false;
		spawner = this.transform;
	}
		
	void Update () {
		if (spawned == false) {
			Vector3 spawnPosition;
			spawnPosition = spawner.position;
			Quaternion spawnRotation = spawner.rotation;
			Instantiate (enemy, spawnPosition, spawnRotation);
			spawned = true;
		}
	}


}
