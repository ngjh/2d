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

				AnsweredCorrectlyData acd = new AnsweredCorrectlyData ();
				acd.MatricNumber = ua.MatricNumber;
				acd.NumCorrectAnswers = "0";
				bool answeredCorrectCreationSuccess = Utility.postArrayToAPI ("AnsweredCorrectly", acd);

				Achievements achiev = new Achievements ();
				achiev.MatricNumber = ua.MatricNumber;
				achiev.CardsObtained = "0";
				achiev.EventsAttended = "0";
				achiev.MaxRarity = "Common";
				achiev.PvPWins = "0";
				achiev.QuestionsAnswered = "0";

				bool achieveCreationSuccess = Utility.postToAPI<Achievements> (achiev);

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
