using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CreateTest : MonoBehaviour {
	Test test;
	Image image;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClick(){
		image = GetComponent<Image>();
		test = GetComponent<Test>();
		test.selectImage ();
	}

	public bool getSelectedImageStatus(){
		return test.getSelectedImageStatus();
	}

	public void setSelectedImageStatus(){
		test.setSelectedImageStatus();
	}

	public Image getImage(){
		return image;
	} 
}
