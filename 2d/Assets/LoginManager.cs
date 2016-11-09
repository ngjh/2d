using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//this script is attached to the login button
public class LoginManager : MonoBehaviour {


	Camera[] cams;
	InputField usernameField, passwordField;

	Camera mainCamera, storyCamera, profileCamera, cardsCamera, mainMenuCamera, loginCamera;

	Canvas gameCanvas, storyCanvas, loginCanvas, mainMenuCanvas, profileCanvas, CardsCanvas, eventCanvas, leaderboardCanvas,
		signUpCanvas, friendsCanvas, achievementCanvas, addFriendsCanvas, friendsListCanvas, dialogueCanvas;

	Text loginDisplayText, profileName;

	QuestionManager qmgr;

	UserCardCollectionMgr ucm;

	//used for initialisation
	void Start(){
		
		cams = Camera.allCameras;
		Debug.Log (cams.Length);
		ucm = GameObject.FindWithTag ("MainMenuCardsButton").GetComponent<UserCardCollectionMgr> ();
		usernameField = GameObject.FindWithTag("UsernameField").GetComponent<InputField>();
		passwordField = GameObject.FindWithTag ("PasswordField").GetComponent<InputField> ();
		//profileName = GameObject.FindWithTag ("ProfileName").GetComponent<Text> ();

		gameCanvas = GameObject.FindWithTag ("GameCanvas").GetComponent<Canvas> ();
		storyCanvas = GameObject.FindWithTag ("StoryCanvas").GetComponent<Canvas> ();
		loginCanvas = GameObject.FindWithTag ("LoginCanvas").GetComponent<Canvas> ();
		mainMenuCanvas = GameObject.FindWithTag ("MainMenuCanvas").GetComponent<Canvas> ();
		profileCanvas = GameObject.FindWithTag ("ProfileCanvas").GetComponent<Canvas> ();
		CardsCanvas = GameObject.FindWithTag ("CardsCanvas").GetComponent<Canvas> ();
		eventCanvas = GameObject.FindWithTag ("EventCanvas").GetComponent<Canvas> ();
		leaderboardCanvas = GameObject.FindWithTag ("LeaderboardCanvas").GetComponent<Canvas> ();
		signUpCanvas = GameObject.FindWithTag ("SignUpCanvas").GetComponent<Canvas> ();
		friendsCanvas = GameObject.FindWithTag ("FriendsCanvas").GetComponent<Canvas> ();
		achievementCanvas = GameObject.FindWithTag ("AchievementCanvas").GetComponent<Canvas> ();
		addFriendsCanvas = GameObject.FindWithTag ("AddFriendsCanvas").GetComponent<Canvas> ();
		friendsListCanvas = GameObject.FindWithTag ("FriendsListCanvas").GetComponent<Canvas> ();
		dialogueCanvas = GameObject.FindWithTag ("DialogueCanvas").GetComponent<Canvas> ();

		qmgr = eventCanvas.GetComponent<QuestionManager> ();

		gameCanvas.gameObject.SetActive (true);
		storyCanvas.gameObject.SetActive (false);
		loginCanvas.gameObject.SetActive (true);
		mainMenuCanvas.gameObject.SetActive (false);
		profileCanvas.gameObject.SetActive (false);
		CardsCanvas .gameObject.SetActive (false);
		eventCanvas.gameObject.SetActive (false);
		signUpCanvas.gameObject.SetActive (false);
		leaderboardCanvas.gameObject.SetActive (false);
		friendsCanvas.gameObject.SetActive (false);
		achievementCanvas.gameObject.SetActive (false);
		addFriendsCanvas.gameObject.SetActive (false);
		friendsListCanvas.gameObject.SetActive (false);
		dialogueCanvas.gameObject.SetActive (false);


		cams[0].gameObject.SetActive (true);// Maincamera
		cams[1].gameObject.SetActive (false);//dialoguecamera
		cams[2].gameObject.SetActive (false);//storycamera
		cams[3].gameObject.SetActive (false);//leaderboardcamera
		cams[4].gameObject.SetActive (false);//eventcamera
		cams[5].gameObject.SetActive (false);//profilecamera
		cams[6].gameObject.SetActive (false);//cardscamera
		cams[7].gameObject.SetActive (false);//addfriendscamera
		cams[8].gameObject.SetActive(false);//friendslistCamera
		cams[9].gameObject.SetActive(false);//achievementcamera
		cams[10].gameObject.SetActive(false);//friendcamera
		cams[11].gameObject.SetActive(false);//mainmenucamera
		cams [12].gameObject.SetActive (true);//logincamera
		cams[13].gameObject.SetActive(false);//signupcamera

		loginDisplayText = GameObject.FindWithTag ("LoginDisplayText").GetComponent<Text> ();

	}

	//attemps to log the user in by first checking if the user exists, if the user exists and the username and password is correct, proceed with login
	public void login(){
		UserAccounts userAccount;
		userAccount = Utility.getFromAPI<UserAccounts> (usernameField.text);

		if (userAccount != null) {
			if (string.Compare (usernameField.text, userAccount.getMatricNumber ()) == 0
				&& string.Compare(passwordField.text, userAccount.Password) == 0) {
				UserAccountholder ua = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();
				ua.ua = userAccount;

				//profileName.text = userAccount.FirstName;
				cams [11].gameObject.SetActive (true);
				cams [12].gameObject.SetActive (false);
				mainMenuCanvas.gameObject.SetActive (true);
				loginCanvas.gameObject.SetActive (false);
			} else {
				loginDisplayText.text = "ERROR, INVALID PASSWORD";
			}

		}
		else{
			loginDisplayText.text = "ERROR, INVALID USERNAME OR CHECK INTERNET CONNECTION";
		}
	}



		
}
