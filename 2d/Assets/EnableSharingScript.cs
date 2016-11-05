using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnableSharingScript : MonoBehaviour {

	public void checkIfFBAccount(){
		UserAccountholder ua = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();
		Button shareButton = GameObject.FindWithTag ("SharetoFBButton").GetComponent<Button> ();


		if (string.Compare (ua.ua.Facebook, "0") == 0)
			shareButton.interactable = false;
		else
			shareButton.interactable = true;

	}


}
