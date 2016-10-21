using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class QuestionManager : MonoBehaviour {
	
	Questions questions;
	Text questionText, option1Text, option2Text, option3Text, option4Text;
	bool questionAnswered = false, answeredCorrectly = false;
	string correctAnswer;
	void OnEnable(){
		questionAnswered = false;
		answeredCorrectly = false;

		questions = Utility.getFromAPI<Questions> (Random.Range (1, 11).ToString ());
		if (questions != null) {
			questionText = GameObject.FindWithTag ("QuestionText").GetComponent<Text> ();
			option1Text = GameObject.FindWithTag ("Option1Text").GetComponent<Text> ();
			option2Text = GameObject.FindWithTag ("Option2Text").GetComponent<Text> ();
			option3Text = GameObject.FindWithTag ("Option3Text").GetComponent<Text> ();
			option4Text = GameObject.FindWithTag ("Option4Text").GetComponent<Text> ();

			option1Text.text = questions.A;
			option2Text.text = questions.B;
			option3Text.text = questions.C;
			option4Text.text = questions.D;
			questionText.text = questions.Question;

		} else {
			questionText = GameObject.FindWithTag ("QuestionText").GetComponent<Text> ();
			questionText.text = "ERROR, CHECK INTERNET CONNECTION";
		}
	}

	public string getCorrectAnswer(){
		if (string.Compare (questions.CorrectAnswer, "A") == 0)
			return questions.A;
		else if (string.Compare (questions.CorrectAnswer, "B") == 0)
			return questions.B;
		else if (string.Compare (questions.CorrectAnswer, "C") == 0)
			return questions.C;
		else
			return questions.D;
	}

	public bool getQuestionAnswered(){
		return questionAnswered;
	}
	public void setQuestionAnswered(){
		questionAnswered = true;
	}

	public void setAnsweredCorrectly(){
		answeredCorrectly = true;
	}
}
