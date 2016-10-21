using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
	//this script is attached to the panels
	bool panelOccupied = false, panelSelected = false;
	int panelTopValue, panelBottomValue, panelLeftValue, panelRightValue;

	string panelOccupiedByPlayer = "";

	Card card;

	/*void OnEnable(){
		panelOccupied = false;
		panelSelected = false;
		panelTopValue = 0;
		panelBottomValue = 0;
		panelLeftValue = 0;
		panelRightValue = 0;
		panelOccupiedByPlayer = "";
		card = null;
	}*/

	public void setPanelOccupiedP1(){
		panelOccupiedByPlayer = "P1";
		panelOccupied = true;
	}

	public void setPanelOccupiedP2(){
		panelOccupiedByPlayer = "P2";
		panelOccupied = true;
	}

	public void setPanelOccupiedNoPlayers(){
		panelOccupiedByPlayer = "";
	}

	public void setPanelAboveValue(int value){
		panelTopValue = value;
	}

	public void setPanelBelowValue(int value){
		panelBottomValue = value;
	}

	public void setPanelLeftValue(int value){
		panelLeftValue = value;
	}

	public void setPanelRightValue(int value){
		panelRightValue = value;
	}

	public void setPanelSelectedStatus(){
		
		panelSelected = !panelOccupied;
	}

	public void setPanelOccupiedFalse(){
		panelOccupied = false;
	}

	public void setPanelSelectedFalse(){
		panelSelected = false;
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
