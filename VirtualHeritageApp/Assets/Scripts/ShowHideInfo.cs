using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowHideInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GameObject infoObj;
//	public bool show = false;


	public void OnPointerEnter(PointerEventData eventData) {

//		print ("enter");
		infoObj.SetActive (true);
	
	}

	public void OnPointerExit(PointerEventData eventData) {
//		print ("exit");
		infoObj.SetActive (false);
	}
}
