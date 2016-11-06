using UnityEngine;
using System.Collections;
//script attached to challenge button of friendCanvas
public class ChallengeScript : MonoBehaviour {

	string friendMatricNumber;


	//called when a friend is selected in the friend list of friendCanvas
	public bool setSelectedFriend(string friendMatricNumber){
		if (this.friendMatricNumber == null) {
			this.friendMatricNumber = friendMatricNumber;
			return true;
		}
		else{
			return false;
		}
	}
	//deselects a friend
	public void removeSelectedFriend(){
		friendMatricNumber = null;
	}
}
