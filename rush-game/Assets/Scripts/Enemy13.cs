using UnityEngine;
using System.Collections;

public class Enemy13 : MonoBehaviour {

	// Materials for each state
	public Material idleMaterial;
	public Material warnMaterial;
	public Material rushMaterial;

	// Time spent in each state
	public float idleTime = 2f;
	public float warnTime = 1f;
	public float rushTime = 2f;

	// Rush speed
	public float minRushSpeed = 2f;
	public float maxRushSpeed = 4f;

	// Randomness of time spend in each state
	public float timeRange = 0.5f;

	// States
	const int IDLE_STATE = 0;
	const int WARN_STATE = 1;
	const int RUSH_STATE = 2;

	// Current state
	int state = IDLE_STATE;

	// Time remaining till state change
	float time;

	// Rush direction
	Vector3 rush;

	// Rush speed
	float speed;

	// Use this for initialization
	void Start () {
		// Pick time to stay in initial state
		time = Random.Range (0f, 3f);
	}

	// Called every physics update
	void FixedUpdate () {
		// Reduce time remaining in state
		time -= Time.fixedDeltaTime;

		if (time <= 0f) {
			// It's time to change state
			switch (state) {
			case IDLE_STATE:
				// Change material
				renderer.material = warnMaterial;
				// Change time and state
				time += warnTime + Random.Range (-timeRange, timeRange);
				state = WARN_STATE;
				break;
			case WARN_STATE:
				// Pick a direction and speed to rush
				rush = new Vector3(Random.value - 0.5f, 0f, Random.value - 0.5f).normalized;
				speed = Random.Range (minRushSpeed, maxRushSpeed);
				// Change material
				renderer.material = rushMaterial;
				// Change time and state
				time += rushTime + Random.Range (-timeRange, timeRange);
				state = RUSH_STATE;
				break;
			case RUSH_STATE:
				// Change material
				renderer.material = idleMaterial;
				// Change time and state
				time += idleTime + Random.Range (-timeRange, timeRange);
				state = IDLE_STATE;
				break;
			}
		}

		if (state == RUSH_STATE) {
			// Rush in a direction
			rigidbody.MovePosition (rigidbody.position + rush * speed * Time.fixedDeltaTime);
		}
	}

	// Called when this rigidbody has begun touching another rigidbody or collider
	void OnCollisionEnter (Collision collision) {
		if (collision.collider.CompareTag ("Player")) {
			// We hit the player
			Debug.Log ("player hit!");

			// TODO: tell game controller to restart game etc.
		}
	}
}
