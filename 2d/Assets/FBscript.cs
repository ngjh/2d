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
	Text Username, loginDisplayText;
	Image ProfilePic;
	InputField usernameField;

	string firstName, lastName, fbID, matricNumber;
	void Awake ()
	{
		loginDisplayText = GameObject.FindWithTag ("LoginDisplayText").GetComponent<Text> ();
		usernameField = GameObject.FindWithTag("UsernameField").GetComponent<InputField>();
		Username = GameObject.FindWithTag("ProfileName").GetComponent<Text>();
		ProfilePic = GameObject.FindWithTag("ProfileImage").GetComponent<Image> ();
		mainMenuCanvas = GameObject.FindWithTag ("MainMenuCanvas").GetComponent<Canvas> ();
		loginCanvas = GameObject.FindWithTag ("LoginCanvas").GetComponent<Canvas> ();
		cams = Camera.allCameras;
		mainMenuCamera = cams [10];
		loginCamera = cams [11];

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
		matricNumber = usernameField.text;
		if (string.Compare (matricNumber, null) == 0) {
			loginDisplayText.text = "Please enter your matric number";
		} else {
			
			UserAccounts userAccount = Utility.getFromAPI<UserAccounts> (matricNumber);
			if(userAccount == null){
				FB.LogInWithReadPermissions (perms, AuthCallbackWithAccountCreation);

					
			}
			else{
				FB.LogInWithReadPermissions (perms, AuthCallback);
				UserAccountholder ua = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();
				ua.ua = userAccount;
			}

		}
	}

	private IEnumerator createAccount(){

		while (firstName == null && lastName == null && fbID == null) {
			yield return new WaitForSeconds(1);
		}
		UserAccounts userAccount = new UserAccounts(matricNumber, "facebook", firstName,lastName,
			System.DateTime.Now.ToString(), fbID);
		bool succ = Utility.postToAPI<UserAccounts> (userAccount);
		if(succ){
			Debug.Log("FB ACC creation Successfull");

			AnsweredCorrectlyData acd = new AnsweredCorrectlyData ();
			acd.MatricNumber = matricNumber;
			acd.NumCorrectAnswers = "0";
			bool answeredCorrectCreationSuccess = Utility.postArrayToAPI ("AnsweredCorrectly", acd);

			UserAccountholder ua = GameObject.FindWithTag ("UserAccountHolder").GetComponent<UserAccountholder> ();
			Achievements achiev = new Achievements ();
			achiev.MatricNumber = matricNumber;
			achiev.CardsObtained = "0";
			achiev.EventsAttended = "0";
			achiev.MaxRarity = "Common";
			achiev.PvPWins = "0";
			achiev.QuestionsAnswered = "0";

			bool achieveCreationSuccess = Utility.postToAPI<Achievements> (achiev);
			for(int i = 1; i <= 5; i ++){
				bool cardCreationSuccess = Utility.postArrayToAPI ("CardsOwned", new CardsOwnedData (matricNumber, i.ToString()));
				if(!cardCreationSuccess)
					i--;
				if(i < 0)
					i = 0;
			}
			ua.ua = userAccount;
		}
		else{
			mainMenuCanvas.gameObject.SetActive (false);
			mainMenuCamera.gameObject.SetActive (false);
			loginCamera.gameObject.SetActive (true);
			loginCanvas.gameObject.SetActive (true);
		}
	}

	private void AuthCallbackWithAccountCreation (ILoginResult result) {
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
			StartCoroutine (createAccount ());
			DealWithFBMenus (FB.IsLoggedIn);
		}
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
			FB.API ("/me?fields=last_name", HttpMethod.GET, DisplayLastname);
			FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
			FB.API("/me?fields=id",HttpMethod.GET, DisplayID);

		} else {
			//DialogLoggedIn.SetActive (false);
			//DialogLoggedOut.SetActive (true);
		}
	}

	void DisplayUsername(IResult result) {
		

		if (result.Error == null) {
			Username.text = result.ResultDictionary ["first_name"].ToString();
			firstName = result.ResultDictionary ["first_name"].ToString();;
		} else {
			Debug.Log (result.Error);
		}
	}

	void DisplayLastname(IResult result) {


		if (result.Error == null) {
			Username.text = result.ResultDictionary ["last_name"].ToString();
			lastName = result.ResultDictionary ["last_name"].ToString();
		} else {
			Debug.Log (result.Error);
		}
	}

	void DisplayProfilePic(IGraphResult result) {
		if (result.Texture != null) {
			

			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		}
	}

	void DisplayID(IResult result){
		if (result.Error == null) {
			Debug.Log (result.ResultDictionary ["id"].ToString ());
			fbID = result.ResultDictionary ["id"].ToString ();
		} else {
			Debug.Log (result.Error);
		}
	}

	public void FBShare() {
		Achievements achiev = Utility.getFromAPI<Achievements> (matricNumber);
		FB.ShareLink (
			contentTitle:"GoodGame message",
			contentURL:new System.Uri("http://google.com"),
			contentDescription: "MatricNumber: " + achiev.MatricNumber + "\n"
			+ "QuestionsAnswered: " + achiev.QuestionsAnswered + "\n"
			+ "PvPWins: " + achiev.PvPWins + "\n"
			+ "CardsObtained: " + achiev.CardsObtained + "\n"
			+ "EventsAttended: " + achiev.EventsAttended + "\n"
			+ "MaxRarity: " + achiev.MaxRarity + "\n",
			callback:OnShare
		);
	}	

	void OnShare(IShareResult result) {
		if (result.Cancelled || !string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("SharedLink error: " + result.Error);
		} 
		else if (!string.IsNullOrEmpty(result.PostId)) {
			Debug.Log (result.PostId);
		}
		else 
			Debug.Log("SHARE succeeded");
	}
}



