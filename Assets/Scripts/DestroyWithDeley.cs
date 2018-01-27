/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDeley : MonoBehaviour {
	public float delay;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Destroy (gameObject, delay);
	}
}
