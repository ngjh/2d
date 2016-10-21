using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FBscript : MonoBehaviour {

	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	public GameObject DialogUsername;
	public GameObject DialogProfilePic;
	Camera[] cams;
	Canvas mainMenuCanvas, loginCanvas;
	Camera mainMenuCamera, loginCamera;
	Text Username;
	Image ProfilePic;
	void Awake ()
	{
		Username = GameObject.FindWithTag("ProfileName").GetComponent<Text>();
		ProfilePic = GameObject.FindWithTag("ProfileImage").GetComponent<Image> ();
		mainMenuCanvas = GameObject.FindWithTag ("MainMenuCanvas").GetComponent<Canvas> ();
		loginCanvas = GameObject.FindWithTag ("LoginCanvas").GetComponent<Canvas> ();
		cams = Camera.allCameras;
		mainMenuCamera = cams [5];
		loginCamera = cams [6];
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init (InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp ();
		}
	}


	private void SetInit() {
		Debug.Log ("FB Init Done.");

		if (FB.IsLoggedIn) {
			Debug.Log ("FB Logged In");
		} else {
			Debug.Log ("FB is not Logged In");
		}

		//DealWithFBMenus (FB.IsLoggedIn);
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp ();
			SetInit ();
		} else {
			Debug.Log ("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	// On Facebook login button 
	public void FBLogin() {
		List<string> perms = new List<string> (){"public_profile, email"};

		FB.LogInWithReadPermissions(perms, AuthCallback);
	}

	private void AuthCallback (ILoginResult result) {
		if (result.Error != null) {
			Debug.Log ("This is an error message");
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is Logged In");

				mainMenuCanvas.gameObject.SetActive (true);
				mainMenuCamera.gameObject.SetActive (true);
				loginCamera.gameObject.SetActive (false);
				loginCanvas.gameObject.SetActive (false);
			} else {				
				Debug.Log ("FB is not Logged In");
			}

			DealWithFBMenus (FB.IsLoggedIn);
		}
	}

	void DealWithFBMenus(bool isLoggedIn) {
		if (isLoggedIn) {
			//DialogLoggedIn.SetActive (true);
			//DialogLoggedOut.SetActive (false);

			FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
			FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);

		} else {
			//DialogLoggedIn.SetActive (false);
			//DialogLoggedOut.SetActive (true);
		}
	}

	void DisplayUsername(IResult result) {
		

		if (result.Error == null) {
			Username.text = result.ResultDictionary ["first_name"].ToString();

		} else {
			Debug.Log (result.Error);
		}
	}

	void DisplayProfilePic(IGraphResult result) {
		if (result.Texture != null) {
			

			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		}
	}
}



