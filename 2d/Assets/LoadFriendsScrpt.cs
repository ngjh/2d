using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadFriendsScrpt : MonoBehaviour {

	// Use this for initialization
	public GameObject FriendListEntry, FriendListGrid;
	AnsweredCorrectlyArray ac;
	AnsweredCorrectlyData[] acd;
	GameObject friendListEntry;




	public void displayEntries(){

		foreach (Transform childTransform in FriendListGrid.transform)//clear all cards being displayed
			Destroy (childTransform.gameObject);


		//if (!displayed) {

		string json = Utility.getArrayFromAPI ("Friends");

		ac = JsonUtility.FromJson<AnsweredCorrectlyArray> (json);
		acd = ac.AnsweredCorrectly;

		foreach (AnsweredCorrectlyData a in acd) {

			friendListEntry = Instantiate (FriendListEntry) as GameObject;

			friendListEntry.transform.SetParent (FriendListGrid.transform, false);

			Transform thisNameText = friendListEntry.transform.Find ("FriendEntryText");
			Text nameText = thisNameText.GetComponent<Text> ();


			nameText.text = a.MatricNumber;



		}


		//updateEntries ();

	}
}
