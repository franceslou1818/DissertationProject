using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightObject : MonoBehaviour {

	private Renderer myRenderer;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;

	void Start() {
		myRenderer = GetComponent<Renderer>();
		SetGazedAt(false);
	}

	public void SetGazedAt(bool gazedAt) {

		print ("highlight");
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
	}


}