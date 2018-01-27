/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

	[SerializeField]
	private GameObject projectile;
	[SerializeField]
	private float projectileForce = 500f;
	private Animator _animator = null;

	Rigidbody2D _rb;
	Transform _transform;

	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponent<Animator> ();
		_transform = gameObject.transform;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			_animator.SetTrigger ("shooting");
			FireProjectile ();
		}
		
	}

	public void FireProjectile(){

		GameObject p = Instantiate (projectile, _transform.position, Quaternion.identity);
		_rb = p.GetComponent<Rigidbody2D> ();
		Physics2D.IgnoreCollision (gameObject.GetComponent<Collider2D> (),
			p.GetComponent<Collider2D>() );
		_rb.AddForce((_transform.right)*projectileForce*_transform.localScale.x);
		p.transform.localScale = _transform.localScale;
		p.transform.localScale = 7 * p.transform.localScale;//why I cannot change from Unity?
	}
}
