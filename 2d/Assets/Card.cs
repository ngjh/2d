using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Card : MonoBehaviour {

	//this script is attached to the cards
	Text[] displayedValue;
	Text  txt;
	Image image ;
	bool selected = false;
	bool moveable = true;
	bool initialised = false;
	int topValue, botValue, leftValue, rightValue;

	string cardOwner;

	Vector3 cardVectorPos;
	// Use this for initialization
	void Start () {
		
		image = GetComponent<Image>();
		displayedValue = GetComponentsInChildren<Text> ();

		topValue = Random.Range (1, 10);
		leftValue = Random.Range (1, 10);
		rightValue = Random.Range (1, 10);
		botValue = Random.Range (1, 10);

		displayedValue [0].text = topValue.ToString ();
		displayedValue [1].text = leftValue.ToString ();
		displayedValue [2].text = rightValue.ToString ();
		displayedValue [3].text = botValue.ToString ();

		cardVectorPos = image.transform.position;
		initialised = true;
	}

	void OnEnable(){
		if (initialised) {
			image.transform.position = cardVectorPos;
			selected = false;
			moveable = true;
			cardOwner = "";
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
}
