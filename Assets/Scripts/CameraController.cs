/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dynamic Camera

public class CameraController : MonoBehaviour {
	public Transform robot;
	public float smoothing = 5f;

	Vector3 offset;


	public void Start() {
		offset = transform.position - robot.position;
	
	}



	void FixedUpdate () {
		Vector3 targetCamPosition = robot.position + offset;
			transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime);
	}
}



