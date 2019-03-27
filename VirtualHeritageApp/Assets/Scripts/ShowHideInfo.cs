using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// information corresponding to an orb in the virtual world is shown when hovered over.
public class ShowHideInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GameObject infoObj;

	public void OnPointerEnter(PointerEventData eventData) {

		infoObj.SetActive (true);
	
	}

	public void OnPointerExit(PointerEventData eventData) {
		infoObj.SetActive (false);
	}
}
