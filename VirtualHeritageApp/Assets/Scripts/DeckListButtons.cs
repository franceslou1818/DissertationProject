using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// These are behaviours of the buttons on canvases - "select scene to explore" and "select deck to learn"
public class DeckListButtons : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

	public Color redCol = Color.red;
	public Color highlightedCol = Color.green;
	public Color normalCol = Color.blue;


	MapScript mapScript;

	GameObject mapCanvasNeeded = null;


	void Awake() {
		mapScript = GameObject.Find("MapScript").GetComponent<MapScript>();
	}
	void Start () {
		this.gameObject.GetComponent<Image> ().color = normalCol;

	}

	// when controller touchpas is clicked while the current button is clicked.
	public void OnPointerClick(PointerEventData pointerEventData) {
		GameObject btnClicked = this.gameObject;

		PlayerPrefs.SetString ("selectBtnSelected", btnClicked.name);

		SetObjsActive(btnClicked);
		swapImgToArrow (btnClicked);
	}

	public void OnPointerEnter(PointerEventData pointerEventData) {
		this.gameObject.GetComponent<Image> ().color = highlightedCol;
	}
	public void OnPointerExit(PointerEventData pointerEventData) {
		this.gameObject.GetComponent<Image> ().color = normalCol;
	}


	// when a button is clicked, canvases all around change.
	public void SetObjsActive(GameObject btnClicked) {

		foreach (GameObject[] objArr in mapScript.allButtons) {

			// changing buttons on the "select deck to learn" canvas
			if (btnClicked==objArr[0]) {
				mapCanvasNeeded = objArr[1];
				objArr[1].SetActive (true);

				// changing buttons/information on maps
				if (objArr.Length != 2) {
					GameObject buttonObj = GameObject.Find (objArr[2].name);
					ButtonClick bc = buttonObj.GetComponent<ButtonClick>();
					bc.setOnlyThisActiveOrNot (true);
				}
			} else {
				objArr[1].SetActive (false);
			}
				
		}
		mapCanvasNeeded.SetActive (true);

	}

	// image on buttons on canvases is changed, either an arrow or the the image representing what the button does.
	public void swapImgToArrow(GameObject btnClicked) {

		foreach (GameObject[] objArr in mapScript.allButtons) {

			if (btnClicked == objArr [0] ) { // show arrow
				btnClicked.transform.GetChild (1).gameObject.SetActive (false);
				btnClicked.transform.GetChild (2).gameObject.SetActive (true);	
			} else { // do not show arrows
				objArr[0].transform.GetChild (1).gameObject.SetActive (true);
				objArr[0].transform.GetChild (2).gameObject.SetActive (false);
			}

			if (objArr.Length == 2 && objArr [1] == mapCanvasNeeded) {
				objArr[0].transform.GetChild (1).gameObject.SetActive (false);
				objArr[0].transform.GetChild (2).gameObject.SetActive (true);	
			}

		}

	}

}
