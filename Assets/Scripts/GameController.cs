using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroid;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnAsteroid", 0, 10f);
	}

	void SpawnAsteroid() {
		Vector3 randomPosition = Random.onUnitSphere;
		Vector3 spawnPosition = new Vector3 (randomPosition.x * 20f, randomPosition.y * 20f, randomPosition.z * 20f);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (asteroid, spawnPosition, spawnRotation);
	}

	public void GameOver() {
		CancelInvoke ("SpawnAsteroid");
	}
}
