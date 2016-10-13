using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class CardClickManager : EventTrigger {
	//this script is attached to the cards

	Card card, previousSelectedCard;

	CardPositionUpdater cardPos;


	void OnEnable(){
		card = null;
		previousSelectedCard = null;
	}


	public override void OnPointerClick( PointerEventData data )
	{
		
		card = GetComponent<Card> ();
		cardPos = GetComponentInParent<CardPositionUpdater> ();
		previousSelectedCard = cardPos.getSelectedCard ();
		if (previousSelectedCard != card && previousSelectedCard !=null) {//deselect previous card
			previousSelectedCard.setImageSelectedToFalse ();
			if (string.Compare (previousSelectedCard.getCardOwner (), "P1") == 0)	//TO SET SELECTED IMAGE BACK TO ITS ORIGINAL COLOR
				previousSelectedCard.turnBlue ();
			else
				previousSelectedCard.turnRed ();
		}


		card.selectImage ();	//set selected card
		Debug.Log( card.getImageSelectedStatus());
		if (card.getImageSelectedStatus ()) {
			card.turnYellow ();	//visual indication of selected card
			cardPos.setSelectedCard(card);	//tell CardPositionUpdater which card is selected
		}
			
	}




}
