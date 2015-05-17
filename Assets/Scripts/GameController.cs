using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroid;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnAsteroid", 0, 6f);
	}

	void SpawnAsteroid() {
		Vector3 randomPosition = Random.onUnitSphere;
		Vector3 spawnPosition = new Vector3 (randomPosition.x * 8f, randomPosition.y * 8f, randomPosition.z * 8f);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (asteroid, spawnPosition, spawnRotation);
	}
}
