using UnityEngine;
using System.Collections;
[System.Serializable]
//this two classes are used to contain the json string contents
public class AllCards {

	public CardsData[] Cards;
}
[System.Serializable]
public class CardsData{
	public string CardID;
	public string CardName;
	public string TopValue;
	public string BotValue;
	public string LeftValue;
	public string RightValue;
}
