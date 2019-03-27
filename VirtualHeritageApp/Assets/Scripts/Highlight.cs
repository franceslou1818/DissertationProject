using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// highlighting doors in the virtual world while raycast is hovered over them
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

		if (lookingAtObject==true) {
			selectedObject.GetComponent<Renderer> ().material.color
			= new Color32 ( (byte)redCol, (byte)greenCol, (byte)blueCol, (byte)alphaCol);
		}

	}

	public void OnPointerEnter(PointerEventData eventData) {
		redCol = 0;
		greenCol = 0;
		blueCol = 0;
		alphaCol = 0;
		flashingIn = true;
		startedFlashing = false;

		lookingAtObject = true;
		if (startedFlashing == false) {
			startedFlashing = true;
			StartCoroutine (FlashObject());
		}
	}

	public void OnPointerExit(PointerEventData eventData) {

		lookingAtObject = false;
		StopCoroutine (FlashObject());
		selectedObject.GetComponent<Renderer> ().material.color
						= new Color32 ( 255, 255, 255, 255);

	}

	IEnumerator FlashObject() {
		while (lookingAtObject == true) {

			yield return new WaitForSeconds (0.01f);

			if (flashingIn == true) {
				if (blueCol <= 30)
					flashingIn = false;
				else {
					blueCol -= 25;
					greenCol -= 25;
				}
			}

			if (flashingIn == false) {
				if (blueCol >= 250)
					flashingIn = true;
				else {
					blueCol += 25;
					greenCol += 25;
				}
			}

		}
	}


}