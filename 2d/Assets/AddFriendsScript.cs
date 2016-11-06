using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//this script is attached to the addfriends canvas
public class AddFriendsScript : EventTrigger {
	//for initialisation
	void OnEnable(){
		Text displayText = GameObject.FindWithTag ("AddFriendsDisplayText").GetComponent<Text> ();
		displayText.text = "";
	}

	//called when user presses on the addfriend button 
	public override void OnPointerClick( PointerEventData data ){
		InputField userName = GameObject.FindWithTag ("AddFriendsUsernameField").GetComponent<InputField>();
		Text displayText = GameObject.FindWithTag ("AddFriendsDisplayText").GetComponent<Text> ();
		FriendsData fd = new FriendsData ();

		if (userName.text == null) {
			displayText.text = "Invalid Username submitted";
		} else {
			UserAccounts userAccount;
			userAccount = Utility.getFromAPI<UserAccounts> (userName.text);

			if (userAccount != null) {
				UserAccountholder uah = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();
				fd.MatricFriendee = userName.text;
				fd.MatricFriender = uah.ua.MatricNumber;
				bool succ = Utility.postArrayToAPI<FriendsData> ("Friends", fd);
				if (succ)
					displayText.text = "Friend added successfully!";
				else
					displayText.text = "Error adding friend";
			} else {
				displayText.text = "Invalid Username submitted";
			}
		}

	}
}
