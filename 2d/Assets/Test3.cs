using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Test3 : MonoBehaviour {

	Test[] test;
	Image image;
	Canvas canvas;
	bool panelOccupied = false;
	int i, topValue;
	Test2 test2;
	bool topOccupied = false, botOccupied = false;
	// Use this for initialization
	void Start () {
		image = null;
		canvas = GetComponentInParent<Canvas> ();
		test = new Test[9];

		test2 = canvas.GetComponentInChildren<Test2> ();
	}

	// Update is called once per frame
	void Update () {
		if (test2.getOccupiedStatus() && topOccupied != true)
			topOccupied = true;
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
			topValue = 2;//test [i].getValue ();
			if (topOccupied && topValue > test2.getBottomValue ())
				test [i-1].TurnRed ();
		}
	}

	public bool getOccupiedStatus(){
		return panelOccupied;
	}

	public int getTopValue(){
		return topValue;
	}
}
