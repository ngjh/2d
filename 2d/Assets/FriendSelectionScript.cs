using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//attached to the friends matric number text of friendscanvas
public class FriendSelectionScript : EventTrigger {

	bool selected;
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		selected = false;
	}
	//when a username is clicked, the following happens
	public override void OnPointerClick( PointerEventData data ){
		ChallengeScript cs = GameObject.FindWithTag ("ChallengeButton").GetComponent<ChallengeScript> ();
		Text thisText = gameObject.GetComponent<Text> ();
		if (!selected) {
			
			bool succ = cs.setSelectedFriend (thisText.text);
			if (succ)
				thisText.color = Color.yellow;
			else
				thisText.color = Color.white;

			selected = true;
		} else {
			thisText.color = Color.white;
			cs.removeSelectedFriend ();
			selected = false;
		}
	}
}
