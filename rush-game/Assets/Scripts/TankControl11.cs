using UnityEngine;
using System.Collections;

public class TankControl11 : MonoBehaviour {

	// Speed of tank in units per second
	public float speed = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Should be called every FixedUpdate from another script
	public void Control (Vector2 move, Vector2 shoot) {
		Debug.Log ("move: " + move + " shoot: " + shoot);

		// Handle movement
		if (0f < move.sqrMagnitude) {
			// Move the tank's rigid body to its new position
			rigidbody.MovePosition (rigidbody.position + new Vector3 (move.x, 0f, move.y) * speed * Time.fixedDeltaTime);

			// Determine the tank's new angle of rotation
			float a = Mathf.Atan2 (move.x, move.y) * Mathf.Rad2Deg;

			// Move the tank's rigid body to its new rotation
			rigidbody.MoveRotation (Quaternion.AngleAxis (a, Vector3.up));
		}
	}
}
