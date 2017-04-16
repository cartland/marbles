using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float forceMagnitude;

	private Rigidbody player;
	private Vector3 initPosition;
	private Quaternion initRotation;

	void Start() {
		player = GetComponent<Rigidbody> ();
		initPosition = player.transform.position;
		initRotation = player.transform.rotation;
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f,  moveVertical);
		player.AddForce (movement * forceMagnitude);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Wall")) {
			player.transform.SetPositionAndRotation (initPosition, initRotation);
			player.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}
}
