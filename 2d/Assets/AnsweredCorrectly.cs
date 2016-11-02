using UnityEngine;
using System.Collections;
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