using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
	//this script is attached to the panels
	bool panelOccupied = false, panelSelected = false;
	int panelTopValue, panelBottomValue, panelLeftValue, panelRightValue;

	string panelOccupiedByPlayer = "";

	Card card;

	void OnEnable(){
		panelOccupied = false;
		panelSelected = false;
		panelTopValue = 0;
		panelBottomValue = 0;
		panelLeftValue = 0;
		panelRightValue = 0;
		panelOccupiedByPlayer = "";
	}

	public void setPanelOccupiedP1(){
		panelOccupiedByPlayer = "P1";
		panelOccupied = true;
	}

	public void setPanelOccupiedP2(){
		panelOccupiedByPlayer = "P2";
		panelOccupied = true;
	}
		

	public void setPanelAboveOccupied(int value){
		panelTopValue = value;
	}

	public void setPanelBelowOccupied(int value){
		panelBottomValue = value;
	}

	public void setPanelLeftOccupied(int value){
		panelLeftValue = value;
	}

	public void setPanelRightOccupied(int value){
		panelRightValue = value;
	}

	public void setPanelSelectedStatus(){
		
		panelSelected = !panelOccupied;
	}

	public string getPlayerOccupyingPanel(){
		return panelOccupiedByPlayer;
	}

	public bool getPanelOccupiedStatus(){
		return panelOccupied;
	}

	public int getPanelTopValue(){
		return panelTopValue;
	}

	public int getPanelBottomValue(){
		return panelBottomValue;
	}

	public int getPanelLeftValue(){
		return panelLeftValue;
	}

	public int getPanelRightValue(){
		return panelRightValue;
	}

	public bool getPanelSelectedStatus(){
		return panelSelected;
	}

	public Card getCardOccupyingPanel(){
		return card;
	}

	public void setCardOccupyingPanel(Card card){
		this.card = card;
	}
}
