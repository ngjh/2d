using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	bool p1Turn = true;
	bool p2Turn = false;

	Card[] cards;

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
	}
	
	// Update is called once per frame
	void Update () {
	
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

	private void setCardsNotMoveable (){
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
