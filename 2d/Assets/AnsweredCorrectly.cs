using UnityEngine;
using System.Collections;

// this two classes are used to contain the json string contents
[System.Serializable]
public class AnsweredCorrectlyArray{


	public AnsweredCorrectlyData[] AnsweredCorrectly;
	public AnsweredCorrectlyArray(){
	}
}
[System.Serializable]
public class AnsweredCorrectlyData {

	public string MatricNumber;
	public string NumCorrectAnswers;

}