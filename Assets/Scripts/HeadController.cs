/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private float startX;
	[SerializeField]
	private float startY;
	[SerializeField]
	private float endX;
	[SerializeField]
	private int numOfEnemy;
	[SerializeField]
	private int endY;




	private Vector2 _currentPos;
	private Transform _transform;


	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {
		//it sets position of the first enemy
		if (numOfEnemy == 1) {
			if (_currentPos.x >= 0) {
				_currentPos = _transform.position;
				_currentPos -= new Vector2 (speed, speed / 8);
			}

			else if (_currentPos.x < 0) {
				_currentPos = _transform.position;
				_currentPos -= new Vector2 (speed, -speed / 3);
			}
			_transform.position = _currentPos;


			if (_currentPos.x < endX) {
				Reset ();
			}
			//It sets position of the second enemy
		} else if (numOfEnemy == 2) {

			_currentPos = _transform.position;
			_currentPos -= new Vector2 (speed, -speed / 3);
			_transform.position = _currentPos;


			if (_currentPos.x < endX) {
				Reset ();
			}

		}

	}

	//method wich Reset enemies for a random position
	public void Reset(){


		float y1 = Random.Range (startY, endY);

		_transform.position =

			new Vector2 (startX, y1);



	}



}
