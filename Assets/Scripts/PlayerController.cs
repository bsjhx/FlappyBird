using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Rigidbody rigidbody;
	public float speed;
	public float thrust;
	public GameController gameController;


	void Start() {
		rigidbody = GetComponent<Rigidbody>();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot load GameController!");
		}
	}

	void FixedUpdate() {
		if (gameController.isGameOn ()) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				Vector3 v = rigidbody.velocity;
				v.y = 0.0f;
				rigidbody.velocity = v;
				rigidbody.AddForce (transform.up * thrust);
				rigidbody.useGravity = true;
			}
		} else {
			Vector3 v = rigidbody.velocity;
			v.y = 0.0f;
			rigidbody.velocity = v;
			rigidbody.useGravity = false;
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Ground") {
			Vector3 v = rigidbody.velocity;
			v.y = 0.0f;
			rigidbody.velocity = v;
			rigidbody.useGravity = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Ground") {
			gameController.GameOver();
		}
	}
}
