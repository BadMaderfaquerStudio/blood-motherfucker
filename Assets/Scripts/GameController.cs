﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	int scoreValue;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start () {
		StartCoroutine (SpawnWaves ());
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();

	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("main", LoadSceneMode.Single);
			}
		}
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while(true){
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver){
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	public void GameOver () {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

}
