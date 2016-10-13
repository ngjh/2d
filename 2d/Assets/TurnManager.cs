using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
	//this script is attached to the game canvas
	bool p1Turn = true;
	bool p2Turn = false;

	Card[] cards;

	bool initialised = false;
	// Use this for initialization
	void Start () {
		cards = GetComponentsInChildren<Card> ();

		for (int i = 0; i < 5; i++) {
			cards [i].setCardOwner ("P1");
			cards [i].turnBlue ();
		}
			
		for (int i = 5; i < 10; i++) {
			cards [i].setCardOwner ("P2");
			cards [i].turnRed ();
		}
		setCardsNotMoveable ();	
		initialised = true;
	}
	
	// Update is called once per frame
	void OnEnable () {
		if (initialised) {
			p1Turn = true;
			p2Turn = false;
			for (int i = 0; i < 5; i++) {
				cards [i].setCardOwner ("P1");
				cards [i].turnBlue ();
			}

			for (int i = 5; i < 10; i++) {
				cards [i].setCardOwner ("P2");
				cards [i].turnRed ();
			}
			setCardsNotMoveable ();
		}
	}

	public bool getP1Turn(){
		return p1Turn;
	}

	public bool getP2Turn(){
		return p2Turn;
	}

	public void togglePlayerTurn(){
		p1Turn = !p1Turn;
		p2Turn = !p2Turn;
		setCardsNotMoveable ();
	}

	private void setCardsNotMoveable (){	//set cards that are moveable according to player's turn
		if (p1Turn == true) {
			for (int i = 5; i < 10; i++) {
				cards [i].setNotMoveable ();
				cards [i-5].setMoveable ();

			}
			Debug.Log ("P1 turn");
		} 
		else {
			for (int i = 0; i < 5; i++) {
				cards [i].setNotMoveable ();
				cards [i+5].setMoveable ();

			}

			Debug.Log ("P2 turn");
		}
	}
}
