using UnityEngine;
using System.Collections;

public class PanelUpdater : MonoBehaviour {
	//this script is attached to game canvas
	Panel[] panels;
	Card rightCard, leftCard, topCard, bottomCard, currentCard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		panels = GetComponentsInChildren<Panel> ();
		foreach (Panel p in panels) {
			p.setPanelSelectedFalse ();
			p.setPanelOccupiedFalse ();
			p.setPanelLeftValue (0);
			p.setPanelRightValue (0);
			p.setPanelAboveValue (0);
			p.setPanelBelowValue (0);
			p.setPanelOccupiedNoPlayers ();
			p.setCardOccupyingPanel (null);
		}
	}

	public void setColorAccordingToValue(Panel panel){
		int i;// for index of panel
		string s, s2;

		for(i = 0; i < 9; i++)
			if(panels[i] == panel)//to find index of input panel
				break;
		currentCard = panel.getCardOccupyingPanel ();	//get card currently attached to the panel

		if ((i + 3) > 2 && (i + 3 )< 9) {	//turn card on the right to red/blue
			//if (panels [i+3].getCardOccupyingPanel () != null)
			rightCard = panels [i+3].getCardOccupyingPanel ();	//get card on the right of currentCard
			if (rightCard != null && rightCard.getCardLeftValue () < currentCard.getCardRightValue ()) {	//rightcard smaller than currentCard
				s = panels [i+3].getPlayerOccupyingPanel ();	
				s2 = panel.getPlayerOccupyingPanel ();
				if (s =="P2" && s2 == "P1") {
					panels [i+3].setPanelOccupiedP1 ();
					rightCard.turnBlue ();
					rightCard.setCardOwner ("P1");
				} else if (s == "P1" && s2 == "P2") {
					panels [i+3].setPanelOccupiedP2 ();
					rightCard.turnRed ();
					rightCard.setCardOwner ("P2");
				}
			}
		}

		if ((i - 3) >= 0 && (i - 3) < 6) {	//turn card on the left to red/blue
			
			leftCard = panels [i-3].getCardOccupyingPanel ();//get card on the left of currentCard
			if (leftCard != null && leftCard.getCardRightValue () < currentCard.getCardLeftValue ()) {//leftCard smaller than currentCard
				s = panels [i-3].getPlayerOccupyingPanel ();
				s2 = panel.getPlayerOccupyingPanel ();
				if (s =="P2" && s2 == "P1") {
					panels [i-3].setPanelOccupiedP1 ();
					leftCard.turnBlue ();
					leftCard.setCardOwner ("P1");
				} else if (s == "P1" && s2 == "P2") {
					panels [i-3].setPanelOccupiedP2 ();
					leftCard.turnRed ();
					leftCard.setCardOwner ("P2");
				}
			}
		}


		if ((i + 1) % 3 != 0) {		//turn card on the bottom to red/blue
			bottomCard = panels [i+1].getCardOccupyingPanel ();//get card on the bottom of currentCard
			if (bottomCard != null && bottomCard.getCardTopValue () < currentCard.getCardBotValue ()) { //bottomCard smaller than currentCard
				s = panels [i+1].getPlayerOccupyingPanel ();
				s2 = panel.getPlayerOccupyingPanel ();
				if (s == "P2" && s2 == "P1") {
					panels [i+1].setPanelOccupiedP1 ();
					bottomCard.turnBlue ();
					bottomCard.setCardOwner ("P1");
				} else if (s == "P1" && s2 == "P2") {
					panels [i+1].setPanelOccupiedP2 ();
					bottomCard.turnRed ();
					bottomCard.setCardOwner ("P2");
				}
			}
		}

		if ((i + 3) % 3 != 0) {		//turn card on the top to red/blue
			topCard = panels [i-1].getCardOccupyingPanel ();	//get card on the top of currentCard
			if (topCard != null && topCard.getCardBotValue () < currentCard.getCardTopValue ()) {	//topCard smaller than currentCard
				s = panels [i-1].getPlayerOccupyingPanel ();
				s2 = panel.getPlayerOccupyingPanel ();
				if (s == "P2" && s2 == "P1") {
					panels [i-1].setPanelOccupiedP1 ();
					topCard.turnBlue ();
					topCard.setCardOwner ("P1");
				} else if (s == "P1" && s2 == "P2") {
					panels [i-1].setPanelOccupiedP2 ();
					topCard.turnRed ();
					topCard.setCardOwner ("P2");
				}
			}
		}






	}
}
