using UnityEngine;
using System.Collections;

public class DestroyMonsterOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Called when the controller hits a collider while performing a Move
	void OnControllerColliderHit (ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Monster") {
			// Destroy any monsters we hit
			Destroy (hit.gameObject);
		}
	}

}
