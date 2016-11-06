using UnityEngine;
using System.Collections;
//
[System.Serializable]
public class AnswersArray {

	//public AnswersData[] Answers;
}

//used to contain the json string contents are parsing to json
[System.Serializable]
public class Answers{
	public string MatricNumber;
	public string QuestionID;
	public string UserAnswer;
}
