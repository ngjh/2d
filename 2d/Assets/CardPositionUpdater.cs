using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CardPositionUpdater : MonoBehaviour {
	//this script is attached to the game canvas
	Image image;

	Card selectedCard;

	WinLossManager wlm;

	bool cardSelectedEvent = false;

	void Start () {
		
		selectedCard = null;
		wlm = GetComponent<WinLossManager> ();

	}

	public Card getSelectedCard(){
		return selectedCard;
	}

	public void setSelectedCard(Card card){
		selectedCard = card;
	}

	

	void OnEnable () {
		selectedCard = null;
	}

	public bool moveImage(Panel selectedPanel){
		string cardOwner;

		if(selectedCard != null && selectedPanel != null) {
			image = selectedCard.getImage();
			image.transform.position = selectedPanel.transform.position;	//move card to panel position
			cardOwner = selectedCard.getCardOwner ();
			if(cardOwner == "P1")	//set player occupying panel
				selectedPanel.setPanelOccupiedP1 ();
			else
				selectedPanel.setPanelOccupiedP2 ();
			selectedPanel.setCardOccupyingPanel (selectedCard);
			selectedCard.setImageSelectedToFalse();	//deselect image
			selectedCard.setNotMoveable ();	//prevent card in the panels from being moved
			selectedPanel.setPanelSelectedStatus ();	//to deselect panel that has been selected
			if (string.Compare (selectedCard.getCardOwner (), "P1") == 0)	//TO SET SELECTED IMAGE BACK TO ITS ORIGINAL COLOR
				selectedCard.turnBlue ();
			else
				selectedCard.turnRed ();
			selectedCard = null;
			wlm.increaseNumberOfCardsPlaced ();
			return true;	//card movement successful
		}

		return false;
	}



}
