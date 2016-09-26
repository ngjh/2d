using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour {
	Image image ;
	bool selected = false;
	bool moveable = true;
	int value;
	// Use this for initialization
	void Start () {
		value = Random.Range (0, 9);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Test(){}

	public int getValue(){
		return value;
	}

	public void TurnRed(){
		image.color = Color.red;

	}

	public Image getImage(){
		return image;
	}

	public void selectImage(){
		if(moveable){
			image = GetComponent<Image>();
			selected = true;
		}

	}

	public void setNotMoveable(){
		moveable = false;
	}
	public bool getSelectedImageStatus(){
		return selected;
	}

	public void setSelectedImageStatus(){
		selected = false;
	}
}
