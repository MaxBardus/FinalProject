/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	Text HealthLable;
	[SerializeField]
	Text MoneyLable;
	[SerializeField]
	Text LevelOverLable;
	[SerializeField]
	Button resetBt;
	[SerializeField]
	Text HighScoreLable;
	[SerializeField]
	PlayerMovment player;







	private void initiaize () //method with does unavailible GUI components and availible and visible lables for money and lifes
	{

		if (SceneManager.GetActiveScene ().name == "LevelOne") {
			Player.Instance.Money = 0;
			Player.Instance.Health = 100;
		} else {
			Player.Instance.Money = Player.Instance.Money;
			Player.Instance.Health = Player.Instance.Health;
		}
		player.gameObject.SetActive (true);
		LevelOverLable.gameObject.SetActive (false);
		HighScoreLable.gameObject.SetActive (false);
		resetBt.gameObject.SetActive (false);

		HealthLable.gameObject.SetActive (true);
		MoneyLable.gameObject.SetActive (true);




	}

	// Use this for initialization
	void Start () {
		
		Player.Instance.gCtrl = this;
		initiaize ();
	}



	public void gameOver()
	{




		resetBt.gameObject.SetActive (true);

		LevelOverLable.gameObject.SetActive (true);
		HealthLable.gameObject.SetActive (false);
		MoneyLable.gameObject.SetActive (false);
		player.gameObject.SetActive (false);
		HighScoreLable.gameObject.SetActive (true);

	}

	public void updateUI(){

		MoneyLable.text = "Money $: " + Player.Instance.Money;

		if (Player.Instance.Money >= 100 && SceneManager.GetActiveScene ().name == "LevelOne") {
			LevelOverLable.text = "Level 1 is done!";

		} else {
			LevelOverLable.text = "";
		}


		if (Player.Instance.Health <= 0) {
			LevelOverLable.text = "Game Over!";
			HighScoreLable.text = "You have: " + Player.Instance.Money + "$";
		}
		HealthLable.text = "Health: " + Player.Instance.Health + "%";
	}

	public void levelOver(){

		LevelOverLable.gameObject.SetActive (true);
		resetBt.gameObject.SetActive (false);
		HighScoreLable.gameObject.SetActive (false);

		HealthLable.gameObject.SetActive (true);
		MoneyLable.gameObject.SetActive (true);

	}

	// Update is called once per frame
	void Update () {
		
	}
	public void ResetBtnClick(){


		SceneManager.LoadScene ("LevelOne");
	}
}



