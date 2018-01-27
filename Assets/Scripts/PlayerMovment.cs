/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {


	[SerializeField]
	private float speed; 
	public Rigidbody2D playerRgb;
	private Animator myAnimator;
	[SerializeField]
	private float jumpPower;
	[SerializeField]
	GameObject explosion;
	[SerializeField]
	private int damage = 10;
	public int score = 0;
	[SerializeField]
	GameController gameController;

	private AudioSource coinColl;
	private AudioSource headColl;
	private AudioSource killColl;

	public int Score{  //the method which count money when the copter is colliding with coins

		get { return score; }
		set { score = value;
			

		}
	}


	// Use this for initialization
	void Start () {

		playerRgb = gameObject.GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per tick
	void FixedUpdate () {

		float move =   Input.GetAxis ("Horizontal");

		playerRgb.velocity = new Vector2 (move * speed, playerRgb.velocity.y);


		myAnimator.SetFloat ("speed", Mathf.Abs(move));




		float jumping = Input.GetAxis ("Jump");



		if (jumping > 0 && IsGrounded()) 
		{
			playerRgb.AddForce (Vector2.up * jumpPower);
		

		}

			myAnimator.SetBool ("Grounded", !IsGrounded());

		Flip ();

	}

	private bool IsGrounded()
	{

		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		Vector2 pos = gameObject.transform.position;
		RaycastHit2D res = Physics2D.Linecast (
			new Vector2(pos.x, pos.y - (sr.bounds.size.y/2)),
			new Vector2(pos.x, pos.y - (sr.bounds.size.y/2+0.4f))

		                   );
		return res != null && res.collider != null;

	}



	void Flip (){


		if (playerRgb.velocity.x > 0) {

			gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 1);

		} else if (playerRgb.velocity.x < 0) {
			gameObject.transform.localScale = new Vector3 (-0.5f,0.5f,1);

		}

	}

	public void Damage (int damage){
		Player.Instance.Health = Player.Instance.Health - damage;
		if (Player.Instance.Health <= 0) {
			
		}
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "head") 

		{

			HeadController headObj = other.gameObject.GetComponent<HeadController> ();

			Instantiate (explosion).GetComponent<Transform> ().position =
				other.gameObject.GetComponent<Transform> ().position;
			

			Damage (damage);

			headObj.Reset ();
			headColl = other.gameObject.GetComponent<AudioSource> ();
			headColl.Play ();

		}

			if (other.gameObject.tag == "coin") {

			CoinController coinObj = other.gameObject.GetComponent<CoinController> ();
				coinObj.Reset();
			Player.Instance.Money = Player.Instance.Money + 10;
			coinColl = other.gameObject.GetComponent<AudioSource> ();
			coinColl.Play ();

			}

	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "killZone") {

			Damage (2*damage);
			killColl = other.gameObject.GetComponent<AudioSource> ();
			killColl.Play ();

		}
	}
}


public interface IDemageable 
{
	void Damage (int damage);

}

