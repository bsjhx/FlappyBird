using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public Rigidbody rg;
	public float wallSpawnTime;
	public GameObject wall;
	public float minY;
	public float maxY;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	public float wallSpeed;

	private bool gameOver;
	private bool restartGame;
	private int points;



	private float nextWall;

	// Use this for initialization
	void Start () {
		points = 0;
		gameOver = false;
		restartGame = false;
		gameOverText.text = "";
		restartText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			if (Time.time > nextWall) {
				nextWall = Time.time + wallSpawnTime;
				Instantiate (wall, new Vector3 (8, Random.Range (minY, maxY), 0), Quaternion.identity);
				if (points % 2 == 0 && wallSpawnTime > 0.02f) {
					wallSpawnTime -= 0.08f;
				}
			}
		}
		if (restartGame)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void addPoint() {
		points++;
		scoreText.text = "Score: " + points;
	}

	public void addSpeed() {
		wallSpeed += 0.5f;
	}

	public float getPoints() {
		return points;
	}

	public float getSpeed() {
		return wallSpeed;
	}

	public void GameOver() {
		gameOver = true;
		gameOverText.text = "GAME OVER!";
		restartGame = true;
		restartText.text = "Press 'R' to restart";
	}

	public bool isGameOn() {
		return !gameOver;
	}
}
