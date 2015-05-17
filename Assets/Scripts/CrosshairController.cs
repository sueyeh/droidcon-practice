using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrosshairController: MonoBehaviour {
	public bool isLookedAt;
	
	void Update() {
		isLookedAt = Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, Mathf.Infinity);
		
		if (isLookedAt) {
			GetComponent<Image> ().color = Color.red;
		} else {
			GetComponent<Image> ().color = Color.white;
		}
		
	}
}