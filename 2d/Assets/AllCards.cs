using UnityEngine;
using System.Collections;
[System.Serializable]
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
