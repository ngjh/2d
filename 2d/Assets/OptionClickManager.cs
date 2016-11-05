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
		Text displayText = GameObject.FindWithTag ("CorrectWrongDisplayText").GetComponent<Text> ();
		button = GetComponent<Button> ();
		qmgr = GetComponentInParent<QuestionManager> ();
		optionText = button.GetComponentInChildren<Text> ();
		if (qmgr.getQuestionAnswered ()) {
			displayText.text = "Question already answered!";
		} 
		else {
			if (string.Compare (qmgr.getCorrectAnswer (), optionText.text) == 0) {
				qmgr.setQuestionAnswered ();
				qmgr.setAnsweredCorrectly ();

				qmgr.setUserAnswer (optionText.text);
				qmgr.updateDatabase ();
				displayText.text = "Correct answer! You have gained a card";
			} else {
				qmgr.setQuestionAnswered ();
				qmgr.setUserAnswer (optionText.text);
				qmgr.updateDatabase ();
				displayText.text = "Wrong answer";
			}
				
		}



	}


}
