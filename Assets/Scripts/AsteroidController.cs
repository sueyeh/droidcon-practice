using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class AsteroidController: MonoBehaviour {
	private CardboardHead head;
	public GameObject explosion;
	public bool isLookedAt;
	private Image crosshair;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		isLookedAt = GetComponent<CapsuleCollider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

		if (gameObject != null) {
			if (isLookedAt) {
				crosshair.material.color = Color.red;
			} else {
				crosshair.material.color = Color.white;
			}
		}
			
		if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
			Instantiate (explosion, hit.transform.position, hit.transform.rotation);
			ScoreManager.score += 5;
			Destroy (gameObject);
		}
	}
}
