using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour {

	public GameObject LeaderboardEntry, LeaderboardGrid;
	AnsweredCorrectlyArray ac;
	AnsweredCorrectlyData[] acd;
	GameObject leaderboardEntry;
	bool displayed = false;

	List<GameObject> gameObjectList;

	public void displayEntries(){
		if (gameObjectList == null)
			gameObjectList = new List<GameObject> ();
		if (!displayed) {
			//string returnedText = Utility.getArrayFromAPI<AnsweredCorrectly> ();
			string json = Utility.getArrayFromAPI ("AnsweredCorrectly");

			ac = JsonUtility.FromJson<AnsweredCorrectlyArray> (json);
			acd = ac.AnsweredCorrectly;

			foreach (AnsweredCorrectlyData a in acd) {

				leaderboardEntry = Instantiate (LeaderboardEntry) as GameObject;

				leaderboardEntry.transform.SetParent (LeaderboardGrid.transform, false);

				Transform thisNameText = leaderboardEntry.transform.Find ("LeaderboardNameText");
				Text nameText = thisNameText.GetComponent<Text> ();
				Transform thisScoreText = leaderboardEntry.transform.Find ("LeaderboardScoreText");
				Text scoreText = thisScoreText.GetComponent<Text> ();

				nameText.text = a.MatricNumber;
				scoreText.text = a.NumCorrectAnswers;

				gameObjectList.Add (leaderboardEntry);
			}
			displayed = true;
		}
	}
}
