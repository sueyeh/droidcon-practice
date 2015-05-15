using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Crosshair : MonoBehaviour {
	private CardboardHead head;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<CapsuleCollider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
			// Teleport randomly.
			// Vector3 direction = Random.onUnitSphere;
			// direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
			// float distance = 2 * Random.value + 1.5f;
			// transform.localPosition = direction * distance;
			Instantiate (explosion, hit.transform.position, hit.transform.rotation);
			Destroy (gameObject);
		}
	}
}

