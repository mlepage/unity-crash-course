using UnityEngine;
using System.Collections;

public class TankControl14 : MonoBehaviour {

	// Speed of tank in units per second
	public float speed = 1f;

	// How long a reload takes
	public float reload = 0.5f;

	// Shot prefab
	public GameObject shotPrefab;

	// Time before reloaded
	float reloadTime = 0f;

	GameObject turret;
	GameObject gun;

	// Use this for initialization
	void Start () {
		// Get the turret and gun
		turret = transform.FindChild ("Turret").gameObject;
		gun = transform.FindChild ("Turret/Gun").gameObject;
	}
	
	// Should be called every FixedUpdate from another script
	public void Control (Vector2 move, Vector2 shoot) {
		//Debug.Log ("move: " + move + " shoot: " + shoot);

		// Handle movement
		if (0f < move.sqrMagnitude) {
			// Move the tank's rigid body to its new position
			rigidbody.MovePosition (rigidbody.position + new Vector3 (move.x, 0f, move.y) * speed * Time.fixedDeltaTime);

			// Determine the tank's new angle of rotation
			float a = Mathf.Atan2 (move.x, move.y) * Mathf.Rad2Deg;

			// Move the tank's rigid body to its new rotation
			rigidbody.MoveRotation (Quaternion.AngleAxis (a, Vector3.up));
		}

		// Handle reloading
		if (0f < reloadTime) {
			reloadTime -= Time.fixedDeltaTime;
		}

		// Handle turret
		if (0f < shoot.sqrMagnitude) {
			// Determine the turret's new angle of rotation
			float a = Mathf.Atan2 (shoot.x, shoot.y) * Mathf.Rad2Deg;
			
			// Move the turret's transform to its new rotation
			turret.transform.rotation = Quaternion.AngleAxis (a, Vector3.up);

			if (reloadTime <= 0f) {
				// Shoot
				Shoot (a);

				// Start reloading
				reloadTime = reload;
			}
		}
	}

	void Shoot (float a) {
		Instantiate (shotPrefab, gun.transform.position, Quaternion.AngleAxis (a, Vector3.up));
	}
}
