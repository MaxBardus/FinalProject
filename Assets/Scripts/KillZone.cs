﻿/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {
	[SerializeField]
	Transform spawnPoint = null;

	public void OnCollisionEnter2D (Collision2D other){

		other.transform.position = spawnPoint.position;
		Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D> ();
		if (rb) {

			rb.velocity = Vector2.zero;
		}
	}


}
