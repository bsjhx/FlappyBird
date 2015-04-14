using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	// speed of wall
	private float speed;

	// game controller for counting poitns
	public GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot load GameController!");
		}
		speed = gameController.getSpeed ();
	}
	
	void Update () {
		if (gameController.isGameOn ()) {
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		if (transform.position.x < -4) {
			Destroy(gameObject);
			gameController.addPoint ();
			if (gameController.getPoints() % 2 == 0) {
				gameController.addSpeed();	
				speed = gameController.getSpeed();
			}
		}

	}
}
