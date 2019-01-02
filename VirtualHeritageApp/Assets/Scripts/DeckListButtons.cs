using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DeckListButtons : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

	public Color redCol = Color.red;
	public Color highlightedCol = Color.green;
	public Color normalCol = Color.blue;

	GameObject thePlayer;
	PlayerScript playerScript;

	GameObject mapCanvasNeeded = null;

	int counter = 0; // for debugging purposes

	void Awake() {
		thePlayer = GameObject.Find("Player");
		playerScript = thePlayer.GetComponent<PlayerScript>();
	}

	void Start () {
		this.gameObject.GetComponent<Image> ().color = normalCol;
	
//		thePlayer = GameObject.Find("Player");
//		playerScript = thePlayer.GetComponent<PlayerScript>();

	}
		

	public void OnPointerClick(PointerEventData pointerEventData) {
		counter++;
		GameObject btnClicked = this.gameObject;

		PlayerPrefs.SetString ("selectBtnSelected", btnClicked.name);

		SetObjsActive(btnClicked);
		swapImgToArrow (btnClicked);
	}

	public void OnPointerEnter(PointerEventData pointerEventData) {
//		print ("OnPointerEnter" + this.gameObject.name);
		this.gameObject.GetComponent<Image> ().color = highlightedCol;
	}
	public void OnPointerExit(PointerEventData pointerEventData) {
//		print ("OnPointerExit" + this.gameObject.name);
		this.gameObject.GetComponent<Image> ().color = normalCol;
	}


	public void SetObjsActive(GameObject btnClicked) {

//		GameObject mapCanvasNeeded = null;

		foreach (GameObject[] objArr in playerScript.allButtons) {

			if (btnClicked==objArr[0]) {
				mapCanvasNeeded = objArr[1];
				objArr[1].SetActive (true);

				if (objArr.Length != 2) {
//					objArr[2].SetActive (true);
//					playerScript.setOneInfoButtonActive (objArr[2]);
					/*
//					print ("objArr2: " + "Btn-"+objArr[2].name);
					GameObject infoBtn = GameObject.Find ( "Btn-"+objArr[2].name);
					ButtonClick buttonScript = infoBtn.GetComponent<ButtonClick>();
					buttonScript.setButtonActiveOrNot(true);
					*/
					GameObject buttonObj = GameObject.Find (objArr[2].name);
					ButtonClick bc = buttonObj.GetComponent<ButtonClick>();
					bc.setOnlyThisActiveOrNot (true);
				}

			} else {

				objArr[1].SetActive (false);
//				if (objArr.Length != 2) {
////					print ("test2");
//					objArr[2].SetActive (false);
//				}
			}
				
		}
		mapCanvasNeeded.SetActive (true);

	}

//	public void setOneInfoButtonActive(GameObject obj) {}
		
	public void swapImgToArrow(GameObject btnClicked) {
		//		print("allButtons: " + playerScript.allButtons);

//		print("******btnClicked: "  + counter + btnClicked.name);

		foreach (GameObject[] objArr in playerScript.allButtons) {


			if (btnClicked == objArr [0] ) { // show arrow
				btnClicked.transform.GetChild (1).gameObject.SetActive (false);
				btnClicked.transform.GetChild (2).gameObject.SetActive (true);	
			} else { // do not show arrows
				objArr[0].transform.GetChild (1).gameObject.SetActive (true);
				objArr[0].transform.GetChild (2).gameObject.SetActive (false);
			}

			if (objArr.Length == 2 && objArr [1] == mapCanvasNeeded) {
//				print ("objArr: " +  objArr[0].name);
				objArr[0].transform.GetChild (1).gameObject.SetActive (false);
				objArr[0].transform.GetChild (2).gameObject.SetActive (true);	
			}

		}

	}

}
