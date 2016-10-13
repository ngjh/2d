using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraManger : MonoBehaviour {

	// Use this for initialization
	Camera[] cams;
	InputField usernameField, passwordField;

	Camera mainCamera, storyCamera, profileCamera, cardsCamera, mainMenuCamera, loginCamera;

	Canvas gameCanvas, storyCanvas, loginCanvas, mainMenuCanvas, profileCanvas, CardsCanvas, eventCanvas;
	void Start(){
		
		cams = Camera.allCameras;
		Debug.Log (cams.Length);
		usernameField = GameObject.FindWithTag("UsernameField").GetComponent<InputField>();


		gameCanvas = GameObject.FindWithTag ("GameCanvas").GetComponent<Canvas> ();
		storyCanvas = GameObject.FindWithTag ("StoryCanvas").GetComponent<Canvas> ();
		loginCanvas = GameObject.FindWithTag ("LoginCanvas").GetComponent<Canvas> ();
		mainMenuCanvas = GameObject.FindWithTag ("MainMenuCanvas").GetComponent<Canvas> ();
		profileCanvas = GameObject.FindWithTag ("ProfileCanvas").GetComponent<Canvas> ();
		CardsCanvas = GameObject.FindWithTag ("CardsCanvas").GetComponent<Canvas> ();
		eventCanvas = GameObject.FindWithTag ("EventCanvas").GetComponent<Canvas> ();

		gameCanvas.gameObject.SetActive (false);
		storyCanvas.gameObject.SetActive (false);
		loginCanvas.gameObject.SetActive (true);
		mainMenuCanvas.gameObject.SetActive (false);
		profileCanvas.gameObject.SetActive (false);
		CardsCanvas .gameObject.SetActive (false);
		eventCanvas.gameObject.SetActive (false);

		cams[0].gameObject.SetActive (false);// Maincamera
		cams[1].gameObject.SetActive (false);//storycamera
		cams[2].gameObject.SetActive (false);//eventcamera
		cams[3].gameObject.SetActive (false);//profilecamera
		cams[4].gameObject.SetActive (false);//cardscamera
		cams[5].gameObject.SetActive (true);//mainmenucamera
		cams[6].gameObject.SetActive (true);//logincamera

	}

	public void activateMainMenuCamera(){
		
		if (string.Compare (usernameField.text, "test") == 0) {
			
			cams[5].gameObject.SetActive (true);
			cams[6].gameObject.SetActive (false);
		}

		
	}

	//public void storyCamera(){
		//cams [1].gameObject.SetActive (true);
		//cams [2].gameObject.SetActive (false);
		//cams [3].gameObject.SetActive (false);
	//}
}
