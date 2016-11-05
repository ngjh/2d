using UnityEngine;
using System.Collections;

public class ChallengeScript : MonoBehaviour {

	string friendMatricNumber;



	public bool setSelectedFriend(string friendMatricNumber){
		if (this.friendMatricNumber == null) {
			this.friendMatricNumber = friendMatricNumber;
			return true;
		}
		else{
			return false;
		}
	}

	public void removeSelectedFriend(){
		friendMatricNumber = null;
	}
}
