using UnityEngine;
using System.Collections;

public class TankControl8 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Should be called every FixedUpdate from another script
	public void Control (Vector2 move, Vector2 shoot) {
		Debug.Log ("move: " + move + " shoot: " + shoot);

		// TODO: make the tank move and shoot
	}
}
