using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Test2 : MonoBehaviour {
	Test[] test;
	Image image;
	Canvas canvas;
	bool panelOccupied = false;
	int i, bottomValue;
	Test3 test3;
	bool topOccupied, botOccupied;
	// Use this for initialization
	void Start () {
		image = null;
		canvas = GetComponentInParent<Canvas> ();
		test = new Test[9];

		test3 = canvas.GetComponentInChildren<Test3> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (test3.getOccupiedStatus() && botOccupied != true)
			botOccupied = true;
	}

	public void moveImage(){
		
		test = canvas.GetComponentsInChildren<Test> ();

		for (i = 0; i < 9; i++) {
			if (test [i].getSelectedImageStatus ())
				break;
		}
		if (i < 9 && panelOccupied == false) {
			image = test[i].getImage();
			image.transform.position = this.transform.position;
			panelOccupied = true;
			test[i].setSelectedImageStatus ();
			test [i].setNotMoveable ();
			bottomValue = 1;//test [i].getValue ();
			if (botOccupied && bottomValue > test3.getTopValue ())
				test [i].TurnRed ();
		}
	}

	public bool getOccupiedStatus(){
		return panelOccupied;
	}

	public int getBottomValue(){
		return bottomValue;
	}
}
