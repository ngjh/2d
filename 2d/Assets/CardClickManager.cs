using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class CardClickManager : EventTrigger {

	Card card, previousSelectedCard;

	CardPositionUpdater cardPos;





	public override void OnPointerClick( PointerEventData data )
	{
		
		card = GetComponent<Card> ();
		cardPos = GetComponentInParent<CardPositionUpdater> ();
		previousSelectedCard = cardPos.getSelectedCard ();
		if (previousSelectedCard != card && previousSelectedCard !=null) {//deselect previous card
			previousSelectedCard.setImageSelectedToFalse ();
		}


		card.selectImage ();
		Debug.Log( card.getImageSelectedStatus());
		if (card.getImageSelectedStatus ()) {
			
			cardPos.setSelectedCard(card);
		}
			
	}




}
