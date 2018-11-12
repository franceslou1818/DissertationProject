using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

	public float SwipeThreshold = 0.5f;

	private Vector2 _startingPosition; // tracks our starting position
	private Vector2 _currentPosition; // tracks the last position touched
	private bool _startedTouch; // tells us if we started swiping

	void Start () {
		_startedTouch = false;
		_startingPosition = GvrControllerInput.TouchPosCentered;
		_currentPosition = GvrControllerInput.TouchPosCentered;
	}
	
	void Update () {


		if (GvrControllerInput.IsTouching) {

			if (!_startedTouch) {
				
				// Start our swiping motion
				_startedTouch = true;
				_startingPosition = GvrControllerInput.TouchPos;
				_currentPosition = GvrControllerInput.TouchPos;
			}
			else {
				// Tracks our position of where we're swiping
				_currentPosition = GvrControllerInput.TouchPos;
			}
//			Vector2 delta = _currentPosition - _startingPosition;
			DetectSwipe();
			
		}
		else {
			if (_startedTouch) {

				// Let go of our touchpad, see if we made any swiping motions
				_startedTouch = false;
//				Vector2 delta = _currentPosition - _startingPosition;
//				DetectSwipe(delta);
			}

		}

	}
		

	private void DetectSwipe() {

		transform.localEulerAngles = new Vector3
			(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z); 
		

		Vector2 delta = _currentPosition - _startingPosition;
			
		float y = delta.y;
		float x = delta.x;


		if (y > 0 && Mathf.Abs (x) < SwipeThreshold) {
			print ("Swiped down");
			transform.position -= Camera.main.transform.forward * 10f * Time.deltaTime;
//			GetComponent<Rigidbody>().MovePosition -= Camera.main.transform.forward * 10f * Time.deltaTime;

			
		} else if (y < 0 && Mathf.Abs (x) < SwipeThreshold) {
			print ("Swiped up");
			transform.position += Camera.main.transform.forward * 10f * Time.deltaTime;
		} else if (x > 0 && Mathf.Abs (y) < SwipeThreshold) {
			print ("Swiped right");
			transform.Translate(Vector3.right * Time.deltaTime * 10f, Space.Self);
//			transform.position += Camera.main.transform.right * 10f * Time.deltaTime;

		} else if (x < 0 && Mathf.Abs (y) < SwipeThreshold) {
			print ("Swiped left");
			transform.Translate(Vector3.left * Time.deltaTime * 10f, Space.Self);
//			transform.position -= Camera.main.transform.right * 10f * Time.deltaTime;
		}
		
	}


}
