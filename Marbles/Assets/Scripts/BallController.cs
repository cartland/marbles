/*
 * Copyright 2017 Chris Cartland. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
