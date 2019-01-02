//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//
//public class HighlightObject : MonoBehaviour {
//
//	private Renderer myRenderer;
//
//	private Material nonHighlightedMaterial;
//	public Material highlightedMaterial;
//
//	void Start() {
//		nonHighlightedMaterial = GetComponent<Renderer> ().material;
//		myRenderer = GetComponent<Renderer>();
////		SetGazedAt(false);
//	}
//
//	public void StartHighlight() {
//
//		print ("StartHighlight");
////		if (inactiveMaterial != null && gazedAtMaterial != null) {
////			myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
////			return;
////		}
//
//		myRenderer.material = highlightedMaterial;
//	}
//
//	public void StopHighlight() {
//		print ("StopHighlight");
//		myRenderer.material = nonHighlightedMaterial;
//	}
//
//
//
//}