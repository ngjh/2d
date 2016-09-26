using UnityEngine;
using System.Collections;

public class PanelUpdater : MonoBehaviour {

	Panel[] panels;
	Card rightCard, leftCard, topCard, bottomCard, currentCard;
	// Use this for initialization
	void Start () {
		panels = GetComponentsInChildren<Panel> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setColorAccordingToValue(Panel panel){
		int i;
		string s, s2;
		for(i = 0; i < 9; i++)
			if(panels[i] == panel)
				break;
		currentCard = panel.getCardOccupyingPanel ();

		if ((i + 3) > 2 && (i + 3 )< 9) {	//turn card on the right to red/blue
			//if (panels [i+3].getCardOccupyingPanel () != null)
			rightCard = panels [i+3].getCardOccupyingPanel ();
			if (rightCard != null && rightCard.getCardLeftValue () < currentCard.getCardRightValue ()) {
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
			
			leftCard = panels [i-3].getCardOccupyingPanel ();
			if (leftCard != null && leftCard.getCardRightValue () < currentCard.getCardLeftValue ()) {
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
			bottomCard = panels [i+1].getCardOccupyingPanel ();
			if (bottomCard != null && bottomCard.getCardTopValue () < currentCard.getCardBotValue ()) {
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
			topCard = panels [i-1].getCardOccupyingPanel ();
			if (topCard != null && topCard.getCardBotValue () < currentCard.getCardTopValue ()) {
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
