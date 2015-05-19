using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AsteroidController: MonoBehaviour {
	private CardboardHead head;
	public GameObject explosion;
	public bool isLookedAt;
	public Transform target;
	public float speed;
	
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		target = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameOver == false) {
			// Moves the Asteroid toward the camera at a given speed
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);

			// Colliders have a function called Raycast that takes the a Ray, a RaycastHit, and a maxDistance float
			// 'out' assigns the variable hit with the object that was hit
			RaycastHit hit;
			isLookedAt = GetComponent<CapsuleCollider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
			
			if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
				ScoreManager.score += 5;
				Instantiate (explosion, hit.transform.position, hit.transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}
