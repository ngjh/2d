using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraManger : MonoBehaviour {

	// Use this for initialization
	Camera[] cams;
	InputField usernameField, passwordField;
	Canvas[] canvas;

	void Start(){
		cams = Camera.allCameras;
		usernameField = GameObject.FindWithTag("UsernameField").GetComponent<InputField>();
		canvas = GetComponentsInParent<Canvas> ();
	}

	public void loginCamera(){
		
		if (string.Compare (usernameField.text, "test") == 0) {
			cams [1].gameObject.SetActive (false);
			cams [2].gameObject.SetActive (true);
			cams [3].gameObject.SetActive (false);

		}

		
	}

	public void storyCamera(){
		cams [1].gameObject.SetActive (true);
		cams [2].gameObject.SetActive (false);
		cams [3].gameObject.SetActive (false);
	}
}
