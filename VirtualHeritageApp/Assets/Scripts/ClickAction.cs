﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
			Debug.Log ("Mouse was clicked.");
	}
}
