using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class UserCardCollectionMgr : MonoBehaviour {

	public GameObject cardGrid, card;
	GameObject cardInstance;

	List<GameObject> gameObjectList;

	string matricNumber;

	bool displayed = false;
	public void displayCards(){
		if (gameObjectList == null)
			gameObjectList = new List<GameObject> ();

		if (!displayed) {

			string json = Utility.getArrayFromAPI ("Cards");
			string cardsOwnedJSON = Utility.getArrayFromAPI ("CardsOwned");

			AllCards allCards = JsonUtility.FromJson<AllCards> (json);
			CardsData[] cardsData = allCards.Cards;

			CardsOwnedArray cardsOwnedArray = JsonUtility.FromJson<CardsOwnedArray> (cardsOwnedJSON);
			CardsOwnedData[] cardsOwnedData = cardsOwnedArray.CardsOwned;

			foreach (CardsOwnedData c in cardsOwnedData) {

				if (string.Compare (c.MatricNumber, matricNumber) == 0) {

					foreach (CardsData cd in cardsData) {
						if (string.Compare (c.CardID, cd.CardID) == 0) {
							cardInstance = Instantiate (card) as GameObject;

							cardInstance.transform.SetParent (cardGrid.transform, false);

							CCSelectionScript cc = cardInstance.GetComponent<CCSelectionScript> ();
							cc.setCardData (cd);

							Transform thisTopValueText = cardInstance.transform.Find ("CardTopValueCC");
							Text topValueText = thisTopValueText.GetComponent<Text> ();

							Transform thisBottomValueText = cardInstance.transform.Find ("CardBottomValueCC");
							Text bottomValueText = thisBottomValueText.GetComponent<Text> ();

							Transform thisLeftValueText = cardInstance.transform.Find ("CardLeftValueCC");
							Text leftValueText = thisLeftValueText.GetComponent<Text> ();

							Transform thisRightValueText = cardInstance.transform.Find ("CardRightValueCC");
							Text rightValueText = thisRightValueText.GetComponent<Text> ();

							topValueText.text = cd.TopValue;
							bottomValueText.text = cd.BotValue;
							leftValueText.text = cd.LeftValue;
							rightValueText.text = cd.RightValue;

							gameObjectList.Add (cardInstance);
						}
					}
				}

			}

			displayed = true;
		}

	}

	public void setMatricNumber(string matricNumber){
		this.matricNumber = matricNumber;
	}
}
