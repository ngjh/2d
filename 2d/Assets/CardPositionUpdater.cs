using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CardPositionUpdater : MonoBehaviour {
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

	
	// Update is called once per frame
	void Update () {
		
	}

	public bool moveImage(Panel selectedPanel){
		string cardOwner;

		if(selectedCard != null && selectedPanel != null) {
			image = selectedCard.getImage();
			image.transform.position = selectedPanel.transform.position;
			cardOwner = selectedCard.getCardOwner ();
			if(cardOwner == "P1")
				selectedPanel.setPanelOccupiedP1 ();
			else
				selectedPanel.setPanelOccupiedP2 ();
			selectedPanel.setCardOccupyingPanel (selectedCard);
			selectedCard.setImageSelectedToFalse();
			selectedCard.setNotMoveable ();
			selectedPanel.setPanelSelectedStatus ();

			selectedCard = null;
			wlm.increaseNumberOfCardsPlaced ();
			return true;
		}

		return false;
	}



}
