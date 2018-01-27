/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {


//	Rigidbody2D rb;
	//public bool isForward;


	[SerializeField]
	GameObject expl;
	private AudioSource bulletColl;
	[SerializeField]
	 IDemageable Id;
	// Use this for initialization
	void Start () {

		//rb = GetComponent<Rigidbody2D> ();


		
	}
	
	// Update is called once per frame
	void Update () {


			


	
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.gameObject.tag == "head") 

		{
			Instantiate (expl).GetComponent<Transform> ().position =
				other.gameObject.GetComponent<Transform> ().position;


			HeadController headObj = other.gameObject.GetComponent<HeadController> ();




			headObj.Reset ();

			bulletColl = other.gameObject.GetComponent<AudioSource> ();
			bulletColl.Play ();

			Destroy (gameObject);
		}


	}



}



