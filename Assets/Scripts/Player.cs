/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	static private Player _instance;
	static public Player Instance{
		get { 
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}
	private Player(){
	}

	public GameController gCtrl;

	private int _money = 0;
	private int _health = 100;

	public int Money{  //the method which count money when the copter is colliding with coins

		get { return _money; }
		set { _money = value;
			if (_money >= 100) {

				gCtrl.levelOver ();
				gCtrl.updateUI();


			} else {
				
				gCtrl.updateUI();
			}
		}
	}

	public int Health{

		get { return _health; }
		set { _health = value;
			if (_health <= 0) {

				gCtrl.gameOver ();
				gCtrl.updateUI();


			} else {
				
				gCtrl.updateUI();

			}

		}
	}

}
