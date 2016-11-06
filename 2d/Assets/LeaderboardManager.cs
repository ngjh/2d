using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
//attached to the leaderboard button of the mainmenu canvas, used to display the leaderboard entries in the leaderboard canvas
public class LeaderboardManager : MonoBehaviour {

	public GameObject LeaderboardEntry, LeaderboardGrid;
	AnsweredCorrectlyArray ac;
	AnsweredCorrectlyData[] acd;
	GameObject leaderboardEntry;



	//called when user presses on the leaderboard button in the mainmenu canvas
	public void displayEntries(){

		foreach (Transform childTransform in LeaderboardGrid.transform)//clear all cards being displayed
			Destroy (childTransform.gameObject);


		//if (!displayed) {
			
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

				
			}


			//updateEntries ();

	}

	/*private void updateEntries(){
		string json = Utility.getArrayFromAPI ("AnsweredCorrectly");
		ac = JsonUtility.FromJson<AnsweredCorrectlyArray> (json);
		acd = ac.AnsweredCorrectly;

		foreach (GameObject lbEntry in gameObjectList) {
			 
			Transform thisNameText = lbEntry.transform.Find ("LeaderboardNameText");
			Text nameText = thisNameText.GetComponent<Text> ();
			Transform thisScoreText = lbEntry.transform.Find ("LeaderboardScoreText");
			Text scoreText = thisScoreText.GetComponent<Text> ();
			foreach (AnsweredCorrectlyData a in acd){
				if (string.Compare (nameText.text, a.MatricNumber) == 0) {
					nameText.text = a.MatricNumber;
					scoreText.text = a.NumCorrectAnswers;
				}
			}
		}
		 
	}*/
}
