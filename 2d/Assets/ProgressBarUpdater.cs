using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProgressBarUpdater : MonoBehaviour {
	Image progress;
	Text text;
	// Use this for initialization
	void Start () {
		
		progress = GetComponent<Image> ();
		text = GetComponentInChildren<Text> ();
		progress.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (progress.fillAmount != 1) {
			progress.fillAmount += 0.010f;
			text.text = (progress.fillAmount * 100f).ToString() + "%";
		}
	}
}
