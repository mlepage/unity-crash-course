using UnityEngine;
using System.Collections;

public class Shot15 : MonoBehaviour {

	// Speed of the shot
	public float speed = 6f;

	// Only hit objects with this material
	public Material vulnerableMaterial;

	// Use this for initialization
	void Start () {
		// The shot will move on its own
		rigidbody.velocity = transform.forward * speed;
	}

	// Called when this rigidbody has begun touching another rigidbody or collider
	void OnCollisionEnter (Collision collision) {
		// Compare material to see if it is vulnerable
		if (collision.collider.gameObject.renderer.sharedMaterial == vulnerableMaterial) {
			Debug.Log ("shot an enemy!");
			// TODO: destroy enemy, increase score, etc.
		}

		// Destroy the game object to which this script is attached
		// Don't Destroy (this) as that destroys the script but not the game object
		Destroy (gameObject);
	}
	
}
