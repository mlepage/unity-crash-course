using UnityEngine;
using System.Collections;

public class AutoRotator : MonoBehaviour {
	
	// Amplitude of rotation change about the X axis
	public float xAmp;
	// Frequency of rotation change about the X axis
	public float xFreq = 1;
	
	// Amplitude of rotation change about the Y axis
	public float yAmp;
	// Frequency of rotation change about the Y axis
	public float yFreq = 1;
	
	// Amplitude of rotation change about the Z axis
	public float zAmp;
	// Frequency of rotation change about the Z axis
	public float zFreq = 1;
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Sin (Time.time * xFreq) * xAmp;
		float y = Mathf.Sin (Time.time * yFreq) * yAmp;
		float z = Mathf.Sin (Time.time * zFreq) * zAmp;
		transform.localRotation = Quaternion.Euler (x, y, z);
	}
	
}
