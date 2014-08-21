using UnityEngine;
using System.Collections;

public class DestroyMonsterOnCollision : MonoBehaviour {

	// The on screen label for the score
	public GUIText scoreLabel;

	// The number of monsters destroyed
	private int score = 0;

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

			// Also increase score
			++score;

			// And update the score's GUI text
			scoreLabel.text = "Score: " + score;
		}
	}

}
