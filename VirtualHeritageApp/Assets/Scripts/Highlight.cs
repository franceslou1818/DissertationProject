using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GameObject selectedObject;

	public int redCol;
	public int greenCol;
	public int blueCol;
	public int alphaCol;

	public bool lookingAtObject = false;
	public bool flashingIn = true;
	public bool startedFlashing = false;

	void Update () {

//		print (selectedObject.GetComponent<Renderer> ().material.color.ToString());

		if (lookingAtObject==true) {
//			print ("update");
			selectedObject.GetComponent<Renderer> ().material.color
//			= new Color32 ( (byte)redCol, (byte)greenCol, (byte)blueCol, 255);
			= new Color32 ( (byte)redCol, (byte)greenCol, (byte)blueCol, (byte)alphaCol);



		}

	}

	public void OnPointerEnter(PointerEventData eventData) {
//		Debug.Log ("OnPointerEnter");
		redCol = 0;
		greenCol = 0;
		blueCol = 0;
		alphaCol = 0;
//		lookingAtObject = false;
		flashingIn = true;
		startedFlashing = false;

		lookingAtObject = true;
		if (startedFlashing == false) {
			startedFlashing = true;
			StartCoroutine (FlashObject());
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
//		Debug.Log ("OnPointerExit");

		lookingAtObject = false;
		StopCoroutine (FlashObject());
		selectedObject.GetComponent<Renderer> ().material.color
						= new Color32 ( 255, 255, 255, 255);

	}

	IEnumerator FlashObject() {
		while (lookingAtObject == true) {

			yield return new WaitForSeconds (0.01f);
				
//			print ("redCol: " + redCol);
//			print ("greenCol: " + greenCol);
//			print ("blueCol: " + blueCol);
//			print ("alpha: " + alphaCol);

			if (flashingIn == true) {
				if (blueCol <= 30)
					flashingIn = false;
				else {
//					print ("first");
					blueCol -= 25;
					greenCol -= 25;
//					alphaCol -= 200;
				}
			}

			if (flashingIn == false) {
				if (blueCol >= 250)
					flashingIn = true;
				else {
//					print ("second");
					blueCol += 25;
					greenCol += 25;
//					alphaCol += 200;
				}
			}

		}
	}


}