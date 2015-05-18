using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class AsteroidController: MonoBehaviour {
	private CardboardHead head;
	public GameObject explosion;
	public bool isLookedAt;
	private Image crosshair;
	public Transform target;
	public float speed;
	
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
		target = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameOver == false) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);

			RaycastHit hit;
			isLookedAt = GetComponent<CapsuleCollider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
			
			if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
				Instantiate (explosion, hit.transform.position, hit.transform.rotation);
				ScoreManager.score += 5;
				Destroy (gameObject);
				crosshair.material.color = Color.white;
			}
		}
	}
}
