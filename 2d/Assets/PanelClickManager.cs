using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PanelClickManager : EventTrigger {
	//this script is attached to panel
	Panel panel;

	PanelUpdater panelUpdater;

	CardPositionUpdater pos;

	TurnManager tm;


	public override void OnPointerClick( PointerEventData data )
	{
		bool imageMoved;
		panelUpdater = GetComponentInParent<PanelUpdater> ();
		tm = GetComponentInParent<TurnManager> ();
		panel = GetComponent<Panel> ();
		panel.setPanelSelectedStatus ();	//	select panel that has been clicked on
		Debug.Log( "OnPointerClick called." );
		pos = GetComponentInParent<CardPositionUpdater> ();
		imageMoved = pos.moveImage (panel);
		if (imageMoved) {
			
			tm.togglePlayerTurn ();	//other player's turn
			panelUpdater.setColorAccordingToValue (panel);	//used to  determine which the color of the surrounding cards in the panel
		}
			
	}


		
}
