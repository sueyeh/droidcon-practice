using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrosshairController: MonoBehaviour {
	public bool isLookingAt;
	
	void Update() {
		isLookingAt = Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, Mathf.Infinity);
		
		if (isLookingAt) {
			GetComponent<Image> ().color = Color.red;
		} else {
			GetComponent<Image> ().color = Color.white;
		}
		
	}
}