/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	[SerializeField]
	private float closeDelay = 2f;

	[SerializeField]
	private float openPosition;
	[SerializeField]
	private float closedPosition;
	[SerializeField]
	private float speed = 0.1f;

	private bool isOpen = false;



	// Use this for initialization
	void Start () {
		gameObject.transform.position =
			new Vector2 (gameObject.transform.position.x, closedPosition);
	}

	// Update is called once per frame
	void Update () {
		if (Player.Instance.Money % 100 == 0 && Player.Instance.Money >= 100){
			StartCoroutine ("Open");

		}
	}

	private IEnumerator Open(){
		if (!isOpen) {
			isOpen = true;
			for (float p = closedPosition; p >= openPosition; p = p - speed){
				gameObject.transform.position =
					new Vector2 (gameObject.transform.position.x, p);
				yield return new WaitForSeconds (0.1f);
				
			}

			yield return new WaitForSeconds (closeDelay);
			StartCoroutine ("Close");


		}
	}

	private IEnumerator Close(){
		if (isOpen) {
			isOpen = true;
			Player.Instance.Money = 0;
			for (float p = openPosition; p <= closedPosition; p = p + speed){
				gameObject.transform.position =
					new Vector2 (gameObject.transform.position.x, p);
				yield return new WaitForSeconds (0.1f);

			}


		}
	}
}
