using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this script is attached to profile canvas
public class ProfileManager : MonoBehaviour {
	string matricNumber;
	Text profileName;
	//dsiplays the name of the user
	void OnEnable(){
		UserAccountholder ua = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();

		profileName = GameObject.FindWithTag ("ProfileName").GetComponent<Text> ();

		if (ua.ua != null) {
			matricNumber = ua.ua.MatricNumber;
			profileName.text = ua.ua.FirstName + " " + ua.ua.LastName;
		}
	}
}
