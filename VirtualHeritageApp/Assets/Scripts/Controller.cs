

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


	private bool walking = false;
//	private Vector3 spawnPoint; //needed if we fall off the map

	// Use this for initialization
	void Start () {
		//spawnPoint = transform.position; //initial position
		Cursor.visible = true;
	}

	// Update is called once per frame
	void Update () {

		Cursor.visible = true;

		// move forward if walking
		if (walking) {
			transform.position = transform.position + 
				Camera.main.transform.forward * 10f * Time.deltaTime;
		}

		//Move to initial position if we fall off the map
//		if (transform.position.y < -10f) {
//			transform.position = spawnPoint;
//		}

		/*
		// stop walking if looking at ground
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f,.5f,0));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {
			if (hit.collider.name.Contains ("Floor"))
				walking = false;
			else
				walking = true;
		}
		*/
		if (Camera.main.transform.eulerAngles.x >= 30.0f && Camera.main.transform.eulerAngles.x < 90.0f)
			walking = true;
		else
			walking = false;

	}
}
