using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrosshairController: MonoBehaviour {
	public bool isLookingAt;
	
	void Update() {
		// Unlike for the Asteroid controller, the Raycast function here is called on Physics, not a collider.
		// Raycast takes an origin position, an origin direction, and how long the Raycast can go.
		isLookingAt = Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, Mathf.Infinity);
		
		if (isLookingAt) {
			GetComponent<Image> ().color = Color.red;
		} else {
			GetComponent<Image> ().color = Color.white;
		}
		
	}
}