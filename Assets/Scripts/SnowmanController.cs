/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour {

	[SerializeField]
	private float speed = 2f;
	[SerializeField]
	private float health = 100;
	[SerializeField]
	GameObject expl;

	private Rigidbody2D _rigidBody;
	private Transform _transform;

	private float _width, _height;

	// Use this for initialization
	void Start () {

		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		_transform = gameObject.transform;

		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
		_width = sprite.bounds.extents.x;
		_height = sprite.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 lineCastPos = 
			(Vector2)_transform.position +
			(Vector2)_transform.right * _width -
			(Vector2)_transform.up * _height;

		bool isGrounded =
			Physics2D.Linecast (lineCastPos, lineCastPos + Vector2.down);

		if (!isGrounded) {
			Vector3 curRot = _transform.eulerAngles;
			curRot.y += 180;
			_transform.eulerAngles = curRot;
		}

		Vector2 vel = _rigidBody.velocity;
		vel.x = _transform.right.x * speed;
		_rigidBody.velocity = vel;
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "Lazer") {
			Instantiate (expl).GetComponent<Transform> ().position =
				other.gameObject.GetComponent<Transform> ().position;
			health = health - 10;
			if (health <= 0) {
				Player.Instance.Health = Player.Instance.Health + 10;
				Destroy (gameObject);
			} 
		} 


	}
	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.tag == "Player") {
			Player.Instance.Health = Player.Instance.Health - 5;
		}

	}
}
