using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class QuestionManager : MonoBehaviour {
	
	Questions questions;
	Text questionText, option1Text, option2Text, option3Text, option4Text;
	bool questionAnswered = false, answeredCorrectly = false;
	string correctAnswer;
	string matricNumber;
	string questionID;
	string userAnswer;
	AnsweredCorrectlyArray ac;
	AnsweredCorrectlyData[] acd;

	void OnEnable(){
		questionAnswered = false;
		answeredCorrectly = false;
		questionID = Random.Range (1, 11).ToString ();
		questions = Utility.getFromAPI<Questions> (questionID);
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

	public void setUserAnswer(string ans){
		if (string.Compare (ans, questions.A) == 0)
			userAnswer = "A";
		else if (string.Compare (ans, questions.B) == 0)
			userAnswer = "B";
		else if (string.Compare (ans, questions.C) == 0)
			userAnswer = "C";
		else
			userAnswer = "D";
	}

	public void updateDatabase(){

		Answers ad = new Answers();
		ad.MatricNumber = matricNumber;
		ad.QuestionID = questionID;
		ad.UserAnswer = userAnswer;

		bool succ = Utility.postToAPI<Answers> (ad);


		/*string json = Utility.getArrayFromAPI ("AnsweredCorrectly");

		ac = JsonUtility.FromJson<AnsweredCorrectlyArray> (json);
		acd = ac.AnsweredCorrectly;

		for(int i = 0 ; i < ac.AnsweredCorrectly.Length; i ++) {
			if (string.Compare (ac.AnsweredCorrectly[i].MatricNumber, matricNumber) == 0) {
				int temp = int.Parse(ac.AnsweredCorrectly[i].NumCorrectAnswers) + 1;
				ac.AnsweredCorrectly [i].NumCorrectAnswers = temp.ToString ();
				Debug.Log (ac.AnsweredCorrectly [i].NumCorrectAnswers);
				bool succ = Utility.postArrayToAPI<AnsweredCorrectlyArray> ("AnsweredCorrectly" ,ac);
				Debug.Log ("QUESTION: " + succ);
				break;
			}
		}*/
	}

	public void setMatricNumber(string matricNumber){
		this.matricNumber = matricNumber;
	}
}
