using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class OptionClickManager : EventTrigger {

	// Use this for initialization

	Button button;
	Text optionText;
	QuestionManager qmgr;


	public override void OnPointerClick(PointerEventData data){
		button = GetComponent<Button> ();
		qmgr = GetComponentInParent<QuestionManager> ();
		optionText = button.GetComponentInChildren<Text> ();
		if (qmgr.getQuestionAnswered ()) {
			Debug.Log ("Question Answered");
		} 
		else {
			if (string.Compare (qmgr.getCorrectAnswer (), optionText.text) == 0) {
				qmgr.setQuestionAnswered ();
				qmgr.setAnsweredCorrectly ();

				qmgr.setUserAnswer (optionText.text);
				qmgr.updateDatabase ();
				Debug.Log ("Correct");
			} else {
				qmgr.setQuestionAnswered ();
				qmgr.setUserAnswer (optionText.text);
				qmgr.updateDatabase ();
				Debug.Log ("Wrong");
			}
				
		}



	}


}
