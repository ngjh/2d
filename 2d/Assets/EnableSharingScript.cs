using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//attached to achievment button of mainmenu canvas
public class EnableSharingScript : MonoBehaviour {
	//check if user currently logged in is a facebook session, if it is, make the share button interactable
	public void checkIfFBAccount(){
		UserAccountholder ua = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();
		Button shareButton = GameObject.FindWithTag ("SharetoFBButton").GetComponent<Button> ();


		if (string.Compare (ua.ua.Facebook, "0") == 0)
			shareButton.interactable = false;
		else
			shareButton.interactable = true;

	}


}
