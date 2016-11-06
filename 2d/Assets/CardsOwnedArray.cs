using UnityEngine;
using System.Collections;
//this two classes are used for parsing into json and from json to following data
[System.Serializable]
public class CardsOwnedArray {

	public CardsOwnedData[] CardsOwned;
}
[System.Serializable]
public class CardsOwnedData{
	public string MatricNumber;
	public string CardID;

	public CardsOwnedData(string MatricNumber, string CardID){
		this.MatricNumber = MatricNumber;
		this.CardID = CardID;
	}
}
