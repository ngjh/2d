using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Card : MonoBehaviour {

	//this script is attached to the cards in the gamecanvas
	Text[] displayedValue;
	Text  txt;
	Image image ;
	bool selected = false;
	bool moveable = false;
	bool initialised = false;
	int topValue = 0, botValue = 0, leftValue = 0, rightValue = 0;

	string cardOwner;

	Vector3 cardVectorPos;
	// Use this for initialization
	void Start () {
		
		image = GetComponent<Image>();
		displayedValue = GetComponentsInChildren<Text> ();

		cardVectorPos = image.transform.position;
		initialised = true;
	}

	void OnEnable(){
		if (initialised) {
			image.transform.position = cardVectorPos;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void setCardOwner(string owner){
		cardOwner = owner;
	}

	public string getCardOwner(){
		return cardOwner;
	}

	public int getCardTopValue(){
		return topValue;
	}

	public int getCardBotValue(){
		return botValue;
	}
	public int getCardLeftValue(){
		return leftValue;
	}
	public int getCardRightValue(){
		return rightValue;
	}

	public void setCardTopValue(int topValue){
		this.topValue = topValue;
	}

	public void setCardBotValue(int botValue){
		this.botValue = botValue;
	}
	public void setCardLeftValue(int leftValue){
		this.leftValue = leftValue;
	}
	public void setCardRightValue(int rightValue){
		this.rightValue = rightValue;
	}


	public void turnRed(){
		if(image == null)
			image = GetComponent<Image>();
		image.color = Color.red;

	}

	public void turnBlue(){
		if(image == null)
			image = GetComponent<Image>();
		image.color = Color.blue;
	}

	public void turnYellow(){
		if(image == null)
			image = GetComponent<Image>();
		image.color = Color.yellow;
	}

	public Image getImage(){
		return image;
	}

	public void selectImage(){
		if(moveable){
			
			selected = true;
		}

	}
		

	public void setNotMoveable(){
		moveable = false;
	}
	public void setMoveable(){
		moveable = true;
	}
	public bool getImageSelectedStatus(){
		return selected;
	}

	public void setImageSelectedToFalse(){
		selected = false;
	}

	public bool getMoveableStatus(){
		return moveable;
	}

	public void updateText(){
		displayedValue [0].text = topValue.ToString ();
		displayedValue [1].text = leftValue.ToString ();
		displayedValue [2].text = rightValue.ToString ();
		displayedValue [3].text = botValue.ToString ();
	}
}
