using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//this script is attached to the challenge button of the main menu canvas and friends button of the profile canvas
public class LoadFriendsScrpt : MonoBehaviour {

	// Use this for initialization
	public GameObject FriendListEntry, FriendListGrid;
	FriendsArray friendsArray;
	FriendsData[] friendsData;
	GameObject friendListEntry;



	// displays the friends list when the challenge button  of the mainmenu canvas and friends button of the profile canvas
	public void displayEntries(){

		foreach (Transform childTransform in FriendListGrid.transform)//clear all cards being displayed
			Destroy (childTransform.gameObject);


		//if (!displayed) {

		string json = Utility.getArrayFromAPI ("Friends");//get from api

		friendsArray = JsonUtility.FromJson<FriendsArray> (json);//parse from json
		friendsData = friendsArray.Friends;

		UserAccountholder uah = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();
		string matricNumber = uah.ua.MatricNumber;

		foreach (FriendsData fd in friendsData) {

			if (string.Compare (matricNumber, fd.MatricFriendee) == 0) {
				friendListEntry = Instantiate (FriendListEntry) as GameObject;

				friendListEntry.transform.SetParent (FriendListGrid.transform, false);

				Transform thisNameText = friendListEntry.transform.Find ("FriendEntryText");
				Text nameText = thisNameText.GetComponent<Text> ();
				nameText.text = fd.MatricFriender;
			} else if (string.Compare (matricNumber, fd.MatricFriender) == 0) {
				friendListEntry = Instantiate (FriendListEntry) as GameObject;

				friendListEntry.transform.SetParent (FriendListGrid.transform, false);

				Transform thisNameText = friendListEntry.transform.Find ("FriendEntryText");
				Text nameText = thisNameText.GetComponent<Text> ();
				nameText.text = fd.MatricFriendee;
			}



		}


		//updateEntries ();

	}
}
