using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PanelClickManager : EventTrigger {

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
		panel.setPanelSelectedStatus ();
		Debug.Log( "OnPointerClick called." );
		pos = GetComponentInParent<CardPositionUpdater> ();
		imageMoved = pos.moveImage (panel);
		if (imageMoved) {
			
			tm.togglePlayerTurn ();
			panelUpdater.setColorAccordingToValue (panel);
		}
			
	}


		
}
