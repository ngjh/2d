﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScrollBarValueChanger : MonoBehaviour {
	//this script is to initialize scrollbar size to 0 and ensure the scrollbar is in the right starting position
	Scrollbar sb;
	void Awake(){
		sb = GetComponent<Scrollbar> ();
	}
	
	// Update is called once per frame
	void Update () {
		sb.size = 0;
	}
}
