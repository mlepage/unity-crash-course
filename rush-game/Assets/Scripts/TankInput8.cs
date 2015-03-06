using UnityEngine;
using System.Collections;

public class TankInput8 : MonoBehaviour {

	TankControl8 control;

	// Use this for initialization
	void Start () {
		// Store a reference to the control script
		control = GetComponent<TankControl8> ();
	}
	
	// Called every physics update
	void FixedUpdate () {
		// TODO: get input from player
		Vector2 move = new Vector2 ();
		Vector2 shoot = new Vector2 ();

		// Call the control script to move and shoot the tank
		control.Control (move, shoot);
	}
}
