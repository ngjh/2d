using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class SetDeckScript : EventTrigger {
	List<CardsData> cardsDataList;
	Card card0, card1, card2, card3, card4, card5, card6, card7, card8, card9;
	void Start(){
		card0 = GameObject.FindWithTag ("Card0").GetComponent<Card> ();
		card1 = GameObject.FindWithTag ("Card1").GetComponent<Card> ();
		card2 = GameObject.FindWithTag ("Card2").GetComponent<Card> ();
		card3 = GameObject.FindWithTag ("Card3").GetComponent<Card> ();
		card4 = GameObject.FindWithTag ("Card4").GetComponent<Card> ();

		card5 = GameObject.FindWithTag ("Card5").GetComponent<Card> ();
		card6 = GameObject.FindWithTag ("Card6").GetComponent<Card> ();
		card7 = GameObject.FindWithTag ("Card7").GetComponent<Card> ();
		card8 = GameObject.FindWithTag ("Card8").GetComponent<Card> ();
		card9 = GameObject.FindWithTag ("Card9").GetComponent<Card> ();
	}


	public override void OnPointerClick( PointerEventData data ){
		

		card0.setCardTopValue (int.Parse(cardsDataList[0].TopValue));
		card0.setCardBotValue (int.Parse(cardsDataList[0].BotValue));
		card0.setCardLeftValue (int.Parse(cardsDataList[0].LeftValue));
		card0.setCardRightValue (int.Parse(cardsDataList[0].RightValue));
		card0.updateText ();

		card1.setCardTopValue (int.Parse(cardsDataList[1].TopValue));
		card1.setCardBotValue (int.Parse(cardsDataList[1].BotValue));
		card1.setCardLeftValue (int.Parse(cardsDataList[1].LeftValue));
		card1.setCardRightValue (int.Parse(cardsDataList[1].RightValue));
		card1.updateText ();

		card2.setCardTopValue (int.Parse(cardsDataList[2].TopValue));
		card2.setCardBotValue (int.Parse(cardsDataList[2].BotValue));
		card2.setCardLeftValue (int.Parse(cardsDataList[2].LeftValue));
		card2.setCardRightValue (int.Parse(cardsDataList[2].RightValue));
		card2.updateText ();

		card3.setCardTopValue (int.Parse(cardsDataList[3].TopValue));
		card3.setCardBotValue (int.Parse(cardsDataList[3].BotValue));
		card3.setCardLeftValue (int.Parse(cardsDataList[3].LeftValue));
		card3.setCardRightValue (int.Parse(cardsDataList[3].RightValue));
		card3.updateText ();

		card4.setCardTopValue (int.Parse(cardsDataList[4].TopValue));
		card4.setCardBotValue (int.Parse(cardsDataList[4].BotValue));
		card4.setCardLeftValue (int.Parse(cardsDataList[4].LeftValue));
		card4.setCardRightValue (int.Parse(cardsDataList[4].RightValue));
		card4.updateText ();

		card5.setCardTopValue (Random.Range(1,10));
		card5.setCardBotValue (Random.Range(1,10));
		card5.setCardLeftValue (Random.Range(1,10));
		card5.setCardRightValue (Random.Range(1,10));
		card5.updateText ();

		card6.setCardTopValue (Random.Range(1,10));
		card6.setCardBotValue (Random.Range(1,10));
		card6.setCardLeftValue (Random.Range(1,10));
		card6.setCardRightValue (Random.Range(1,10));
		card6.updateText ();

		card7.setCardTopValue (Random.Range(1,10));
		card7.setCardBotValue (Random.Range(1,10));
		card7.setCardLeftValue (Random.Range(1,10));
		card7.setCardRightValue (Random.Range(1,10));
		card7.updateText ();

		card8.setCardTopValue (Random.Range(1,10));
		card8.setCardBotValue (Random.Range(1,10));
		card8.setCardLeftValue (Random.Range(1,10));
		card8.setCardRightValue (Random.Range(1,10));
		card8.updateText ();

		card9.setCardTopValue (Random.Range(1,10));
		card9.setCardBotValue (Random.Range(1,10));
		card9.setCardLeftValue (Random.Range(1,10));
		card9.setCardRightValue (Random.Range(1,10));
		card9.updateText ();
	
	}

	public bool addSelectedCard(CardsData cardsData){
		if (cardsDataList == null)
			cardsDataList = new List<CardsData> ();

		if (cardsDataList.Count == 5)
			return false;
		else {
			cardsDataList.Add (cardsData);
			return true;
		}
	}

	public void removeSelectedCard(CardsData cardsData){
		cardsDataList.Remove (cardsData);
	}
}
