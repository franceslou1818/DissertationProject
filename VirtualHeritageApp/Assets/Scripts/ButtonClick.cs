using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

	public Color redCol = Color.red;
	public Color greenCol = Color.green;
	public Color blueCol = Color.blue;


	public GameObject popUpInfo;

	public bool isActive;
	public bool isPointed;

	GameObject thePlayer;
	PlayerScript playerScript;

//	int counter =0;

//	void Start () {
	void Awake () {
		isPointed = false;

		thePlayer = GameObject.Find("Player");
		playerScript = thePlayer.GetComponent<PlayerScript>();

//		print ("-----start: " + this.gameObject.name + (GameObject.Find(this.gameObject.name.Substring(4)) == null));
//		print("Button Click awake");
		if (GameObject.Find (this.gameObject.name.Substring (4)) == null) {
			isActive = false;
			this.gameObject.GetComponent<Image> ().color = blueCol;
		} else {
			isActive = true;
			this.gameObject.GetComponent<Image> ().color = redCol;
		}

	}


	void Update() {
		if (isActive && isPointed) {
			this.gameObject.GetComponent<Image> ().color = Color.magenta;
		} else if ( !isActive && isPointed ) {
			this.gameObject.GetComponent<Image> ().color = greenCol;
		} else if ( isActive && !isPointed ) {
			this.gameObject.GetComponent<Image> ().color = redCol;
		} else if ( !isActive && !isPointed ) {
			this.gameObject.GetComponent<Image> ().color = blueCol;
		}
	}


	public void setOnlyThisActiveOrNot(bool b) {

		foreach (GameObject info in playerScript.popUpInfos) {

//			print ("***test0: " + info.name.Substring(5)+"--"+this.name.Substring(4) 
//				+"****"+ info.name.Substring(5).Equals(this.name.Substring(4)));

			bool isButtonAndInfoEqual = info.name.Substring(5).Equals(this.name.Substring(4));

			if (isButtonAndInfoEqual) {
				info.SetActive (b);
				this.isActive = b;
			} else {
				info.SetActive (false);
				GameObject buttonObj = GameObject.Find ("Btn-"+info.name.Substring(5));
				ButtonClick bc = buttonObj.GetComponent<ButtonClick>();
				bc.isActive = false;
			}
		}

//		print ("end of for each: " + this.gameObject.name + isActive);
	}



	public void OnPointerClick(PointerEventData pointerEventData) {

		if (isActive) {
			setOnlyThisActiveOrNot(false);
		} else {
			setOnlyThisActiveOrNot(true);
		}


		foreach (GameObject[] objArr in playerScript.allButtons) {
			DeckListButtons buttonScript = playerScript.btnWeatherDeckMap [0].GetComponent<DeckListButtons> ();

			if (objArr.Length == 3 && this.gameObject.name.Equals (objArr [2].name)) {

				PlayerPrefs.SetString ("selectBtnSelected", objArr [0].name);
				buttonScript.SetObjsActive (objArr [0]);
				buttonScript.swapImgToArrow (objArr [0]);
				break;
			} else { // no scene with the corresponding button clicked
					buttonScript.SetObjsActive (playerScript.btnWeatherDeckMap [0]);
					buttonScript.swapImgToArrow (playerScript.btnWeatherDeckMap [0]);

			}
		}


	}

	public void OnPointerEnter(PointerEventData pointerEventData) {
//		print ("OnPointerEnter " + this.gameObject.name + isActive);
		isPointed = true;
	}

	public void OnPointerExit(PointerEventData pointerEventData) {
//		print ("OnPointerExit " + this.gameObject.name + isActive);
		isPointed = false;
	}


}
