using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WinLossManager : MonoBehaviour {
	//this script is attached to the game canvas, incharge of determining the winner and loser
	Panel[] panels;

	bool winDisplayed = false;
	int numberOfCardsPlaced = 0, p1Panel=0, p2Panel=0;
	string s;
	// Use this for initialization
	void Start () {
		panels = GetComponentsInChildren<Panel> ();
	}
	

	void OnEnable () {
		winDisplayed = false;
		numberOfCardsPlaced = 0; 
		p1Panel = 0; 
		p2Panel=0;
	}

	// Update is called once per frame to check if the game has ended and determines the winner
	void Update(){
		if (numberOfCardsPlaced == 9 && winDisplayed == false) {
			winDisplayed = true;
			foreach (Panel p in panels) {
				s = p.getPlayerOccupyingPanel();
				if (s == "P1")
					p1Panel++;
				else
					p2Panel++;
			}

			Text displayText = GameObject.FindWithTag ("WinDisplayText").GetComponent<Text> ();

			if (p1Panel > p2Panel)
				displayText.text = "P1 Victory";
			else
				displayText.text = "P2 Victory";

			Debug.Log (p1Panel);
			Debug.Log (p2Panel);



		}
	}

	/*void OnGUI(){
		if (numberOfCardsPlaced == 9 && winDisplayed == false) {
			winDisplayed = true;
			foreach (Panel p in panels) {
				s = p.getPlayerOccupyingPanel();
				if (s == "P1")
					p1Panel++;
				else
					p2Panel++;
			}
			Debug.Log (p1Panel);
			Debug.Log (p2Panel);



		}
		if (winDisplayed) {
			if(p1Panel > p2Panel)
				GUI.Label (new Rect(100, 100, 100f, 20f), "P1 Victory");
			else
				GUI.Label (new Rect(100, 100, 100f, 20f), "P2 Victory");
		}
	}*/

	public void increaseNumberOfCardsPlaced(){
		numberOfCardsPlaced++;
	}
}
