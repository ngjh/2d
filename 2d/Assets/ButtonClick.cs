using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ButtonClick : EventTrigger {

	Camera[] cam;

	// Use this for initialization
	void Start () {
		cam = GetComponentsInParent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnPointerClick( PointerEventData data ){
		cam [1].gameObject.SetActive (true);
		cam [2].gameObject.SetActive (false);
	}
}
