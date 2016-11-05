﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FriendSelectionScript : EventTrigger {

	bool selected;
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnPointerClick( PointerEventData data ){
		ChallengeScript cs = GameObject.FindWithTag ("ChallengeButton").GetComponent<ChallengeScript> ();
		Text thisText = gameObject.GetComponent<Text> ();
		if (!selected) {
			
			bool succ = cs.setSelectedFriend (thisText.text);
			if (succ)
				thisText.color = Color.yellow;
			else
				thisText.color = Color.white;
		} else {
			thisText.color = Color.white;
			cs.removeSelectedFriend ();
		}
	}
}
