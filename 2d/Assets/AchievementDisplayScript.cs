using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//class is used as data holder for the jsonutility to parse
[System.Serializable]
public class Achievements{
	public string MatricNumber;
	public string QuestionsAnswered;
	public string PvPWins;
	public string CardsObtained;
	public string EventsAttended;
	public string MaxRarity;
}
// attached to achievement button in the main menu, 
public class AchievementDisplayScript : MonoBehaviour {

	public GameObject AchievementEntry, AchievementGrid;

	GameObject achievementEntry;



	//displays all achievments of a user
	public void displayEntries(){

		foreach (Transform childTransform in AchievementGrid.transform)//clear all cards being displayed
			Destroy (childTransform.gameObject);


		UserAccountholder ua = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();

		Achievements achiev = Utility.getFromAPI<Achievements> (ua.ua.MatricNumber);




		//display MatricNumber
		achievementEntry = Instantiate (AchievementEntry) as GameObject;

		achievementEntry.transform.SetParent (AchievementGrid.transform, false);

		Transform thisNameText = achievementEntry.transform.Find ("AchievementNameText");
		Text nameText = thisNameText.GetComponent<Text> ();
		Transform thisValueText = achievementEntry.transform.Find ("AchievementValueText");
		Text valueText = thisValueText.GetComponent<Text> ();

		nameText.text = "MatricNumber:";
		valueText.text = achiev.MatricNumber;

		//display QuestionsAnswered
		achievementEntry = Instantiate (AchievementEntry) as GameObject;

		achievementEntry.transform.SetParent (AchievementGrid.transform, false);

		thisNameText = achievementEntry.transform.Find ("AchievementNameText");
		nameText = thisNameText.GetComponent<Text> ();
		thisValueText = achievementEntry.transform.Find ("AchievementValueText");
		valueText = thisValueText.GetComponent<Text> ();

		nameText.text = "QuestionsAnswered:";
		valueText.text = achiev.QuestionsAnswered;


		//display PvPwins
		achievementEntry = Instantiate (AchievementEntry) as GameObject;

		achievementEntry.transform.SetParent (AchievementGrid.transform, false);

		thisNameText = achievementEntry.transform.Find ("AchievementNameText");
		nameText = thisNameText.GetComponent<Text> ();
		thisValueText = achievementEntry.transform.Find ("AchievementValueText");
		valueText = thisValueText.GetComponent<Text> ();

		nameText.text = "PvPwins:";
		valueText.text = achiev.PvPWins;

		//display CardsObtained

		achievementEntry = Instantiate (AchievementEntry) as GameObject;

		achievementEntry.transform.SetParent (AchievementGrid.transform, false);

		thisNameText = achievementEntry.transform.Find ("AchievementNameText");
		nameText = thisNameText.GetComponent<Text> ();
		thisValueText = achievementEntry.transform.Find ("AchievementValueText");
		valueText = thisValueText.GetComponent<Text> ();

		nameText.text = "CardsObtained:";
		valueText.text = achiev.CardsObtained;

		//display EventsAttended

		achievementEntry = Instantiate (AchievementEntry) as GameObject;

		achievementEntry.transform.SetParent (AchievementGrid.transform, false);

		thisNameText = achievementEntry.transform.Find ("AchievementNameText");
		nameText = thisNameText.GetComponent<Text> ();
		thisValueText = achievementEntry.transform.Find ("AchievementValueText");
		valueText = thisValueText.GetComponent<Text> ();

		nameText.text = "EventsAttended:";
		valueText.text = achiev.EventsAttended;

		//display MaxRarity

		achievementEntry = Instantiate (AchievementEntry) as GameObject;

		achievementEntry.transform.SetParent (AchievementGrid.transform, false);

		thisNameText = achievementEntry.transform.Find ("AchievementNameText");
		nameText = thisNameText.GetComponent<Text> ();
		thisValueText = achievementEntry.transform.Find ("AchievementValueText");
		valueText = thisValueText.GetComponent<Text> ();

		nameText.text = "MaxRarity:";
		valueText.text = achiev.MaxRarity;









	}

}
