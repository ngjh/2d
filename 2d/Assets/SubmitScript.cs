using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SubmitScript : EventTrigger {
	InputField usernameText, passwordText, lastNameText, firstNameText;
	Text signUpDisplayText;
	public override void OnPointerClick( PointerEventData data ){
		usernameText = GameObject.FindWithTag ("SUUsernameField").GetComponent<InputField> ();
		passwordText = GameObject.FindWithTag ("SUPasswordField").GetComponent<InputField> ();
		firstNameText = GameObject.FindWithTag ("SUFirstnameField").GetComponent<InputField> ();
		lastNameText = GameObject.FindWithTag ("SULastnameField").GetComponent<InputField> ();
		signUpDisplayText = GameObject.FindWithTag ("SignupDisplayText").GetComponent<Text> ();
		UserAccounts ua = Utility.getFromAPI<UserAccounts> (usernameText.text);

		if (ua == null) {
			ua = new UserAccounts (usernameText.text, passwordText.text, firstNameText.text, lastNameText.text,
				System.DateTime.Now.ToString (), "0");
			bool succ = Utility.postToAPI<UserAccounts> (ua);
			Debug.Log (succ);
			if (succ) {
				signUpDisplayText.text = "Account created successfully!";
				for(int i = 1; i <= 5; i ++){
					bool cardCreationSuccess = Utility.postArrayToAPI ("CardsOwned", new CardsOwnedData (usernameText.text, i.ToString()));
					if(!cardCreationSuccess)
						i--;
					if(i < 0)
						i = 0;
				}
			}
			else
				signUpDisplayText.text = "Account creation failed!";
		} 
		else {
			signUpDisplayText.text = "Account already exist!";
		}
	}
}
