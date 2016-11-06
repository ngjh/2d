using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//attached to the options buttons in the event canvas
public class OptionClickManager : EventTrigger {

	// Use this for initialization

	Button button;
	Text optionText;
	QuestionManager qmgr;

	//called when the options buttons is pressed and updates the question manager on which is option was pressed
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
