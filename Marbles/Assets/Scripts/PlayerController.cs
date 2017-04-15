using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float forceMagnitude;
	public Text countText;
	public Text winText;

	private Rigidbody player;
	private Vector3 initPosition;
	private Quaternion initRotation;
	private int count;

	void Start() {
		player = GetComponent<Rigidbody> ();
		initPosition = player.transform.position;
		initRotation = player.transform.rotation;
		count = 0;
		UpdateCountText ();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f,  moveVertical);
		player.AddForce (movement * forceMagnitude);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			UpdateCountText ();
		} else if (other.gameObject.CompareTag ("Wall")) {
			player.transform.SetPositionAndRotation (initPosition, initRotation);
		}
	}

	void UpdateCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 5) {
			winText.text = "You Win!";
		}
	}
}
