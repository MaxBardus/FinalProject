/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevelController : MonoBehaviour {


	bool hasEnded;
	public string nextLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (hasEnded) {
			
			SceneManager.LoadScene ("LevelTwo");
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("Player")) {
			
			hasEnded = true;


		}
	}
}
