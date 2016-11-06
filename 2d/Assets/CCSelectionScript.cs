using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//this script is attached to the cards in the card collection canvas
public class CCSelectionScript : EventTrigger {

	CardsData card;

	bool selected = false;
	SetDeckScript sds;

	Image iCard;
	void Start(){
		sds = GameObject.FindWithTag ("SetDeckButton").GetComponent<SetDeckScript> ();
		iCard = GetComponent<Image> ();
	}

	void Update(){
		if (selected)
			iCard.color = Color.yellow;
		else
			iCard.color = Color.white;
	}

	//called when cards in the card collection canvas is pressed
	public override void OnPointerClick( PointerEventData data ){
		bool succ;
		if (!selected) {
			succ = sds.addSelectedCard (card);
			if (succ)
				selected = true;
			else
				selected = false;

		} 
		else {
			selected = false;
			sds.removeSelectedCard (card);
		}
	
	}

	public void setCardData(CardsData card){
		this.card = card;
	}
}
