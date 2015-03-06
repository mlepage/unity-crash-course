using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Prefab to spawn
	public GameObject prefab;

	// Number of prefabs to spawn initially
	public float initialCount = 10;

	// Time (in seconds) between each subsequent spawn
	public float spawnTime = 10;

	// Whether to randomize rotation
	public bool randomizeRotation;

	// Time left to wait until next spawn
	float waitTime;

	// Use this for initialization
	void Start () {
		// Initial spawn
		for (int i = 0; i != initialCount; ++i) {
			Spawn ();
		}

		// Set time until next spawn
		waitTime = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		// Count down time left until next spawn
		waitTime -= Time.deltaTime;

		if (waitTime <= 0) {
			// It's time to spawn
			Spawn ();

			// Set time until next spawn
			waitTime = spawnTime;
		}
	}

	void Spawn() {
		// Pick a random location as if this game object were a cube
		float x = transform.position.x + Random.Range (-transform.localScale.x/2, +transform.localScale.x/2);
		float y = transform.position.y + Random.Range (-transform.localScale.y/2, +transform.localScale.y/2);
		float z = transform.position.z + Random.Range (-transform.localScale.z/2, +transform.localScale.z/2);

		// Instantiate a clone of the prefab at the random location, optionally with a random rotation
		Instantiate (prefab, new Vector3 (x, y, z), randomizeRotation ? Random.rotation : Quaternion.identity);
	}

}
