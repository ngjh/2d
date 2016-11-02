using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraManger : MonoBehaviour {

	// Use this for initialization
	Camera[] cams;
	InputField usernameField, passwordField;

	Camera mainCamera, storyCamera, profileCamera, cardsCamera, mainMenuCamera, loginCamera;

	Canvas gameCanvas, storyCanvas, loginCanvas, mainMenuCanvas, profileCanvas, CardsCanvas, eventCanvas, leaderboardCanvas,
		signUpCanvas;

	Text loginDisplayText, profileName;

	QuestionManager qmgr;

	UserCardCollectionMgr ucm;
	void Start(){
		
		cams = Camera.allCameras;
		Debug.Log (cams.Length);
		ucm = GameObject.FindWithTag ("MainMenuCardsButton").GetComponent<UserCardCollectionMgr> ();
		usernameField = GameObject.FindWithTag("UsernameField").GetComponent<InputField>();
		profileName = GameObject.FindWithTag ("ProfileName").GetComponent<Text> ();

		gameCanvas = GameObject.FindWithTag ("GameCanvas").GetComponent<Canvas> ();
		storyCanvas = GameObject.FindWithTag ("StoryCanvas").GetComponent<Canvas> ();
		loginCanvas = GameObject.FindWithTag ("LoginCanvas").GetComponent<Canvas> ();
		mainMenuCanvas = GameObject.FindWithTag ("MainMenuCanvas").GetComponent<Canvas> ();
		profileCanvas = GameObject.FindWithTag ("ProfileCanvas").GetComponent<Canvas> ();
		CardsCanvas = GameObject.FindWithTag ("CardsCanvas").GetComponent<Canvas> ();
		eventCanvas = GameObject.FindWithTag ("EventCanvas").GetComponent<Canvas> ();
		leaderboardCanvas = GameObject.FindWithTag ("LeaderboardCanvas").GetComponent<Canvas> ();
		signUpCanvas = GameObject.FindWithTag ("SignUpCanvas").GetComponent<Canvas> ();

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

		cams[0].gameObject.SetActive (true);// Maincamera
		cams[1].gameObject.SetActive (false);//storycamera
		cams[2].gameObject.SetActive (false);//leaderboardcamera
		cams[3].gameObject.SetActive (false);//eventcamera
		cams[4].gameObject.SetActive (false);//profilecamera
		cams[5].gameObject.SetActive (false);//cardscamera
		cams[6].gameObject.SetActive (false);//mainmenucamera
		cams[7].gameObject.SetActive (true);//logincamera
		cams[8].gameObject.SetActive(false);//signupcamera
		loginDisplayText = GameObject.FindWithTag ("LoginDisplayText").GetComponent<Text> ();

	}

	public void activateMainMenuCamera(){
		UserAccounts userAccount;
		userAccount = Utility.getFromAPI<UserAccounts> (usernameField.text);

		if (userAccount != null) {
			if (string.Compare (usernameField.text, userAccount.getMatricNumber ()) == 0) {
				
				ucm.setMatricNumber (userAccount.MatricNumber);
				qmgr.setMatricNumber (userAccount.MatricNumber);
				profileName.text = userAccount.FirstName;
				cams [6].gameObject.SetActive (true);
				cams [7].gameObject.SetActive (false);
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
