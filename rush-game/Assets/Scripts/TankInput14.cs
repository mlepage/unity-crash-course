using UnityEngine;
using System.Collections;

public class TankInput14 : MonoBehaviour {

	public CNAbstractController moveStick;
	public CNAbstractController shootStick;

	TankControl14 control;

	// Use this for initialization
	void Start () {
		// Store a reference to the control script
		control = GetComponent<TankControl14> ();
	}
	
	// Called every physics update
	void FixedUpdate () {
		// Get input from joysticks
		Vector2 move = new Vector2 (moveStick.GetAxis ("Horizontal"), moveStick.GetAxis ("Vertical"));
		Vector2 shoot = new Vector2 (shootStick.GetAxis ("Horizontal"), shootStick.GetAxis ("Vertical"));

		// Call the control script to move and shoot the tank
		control.Control (move, shoot);
	}
}
