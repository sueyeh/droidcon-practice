using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroid;
	private Text gameOverText;
	private Text restartText;
	public static bool gameOver;
	private GameObject crosshair;

	// Use this for initialization
	void Start () {
		GameObject gameOverTextObject = GameObject.FindGameObjectWithTag ("GameOverText");
		gameOverText = gameOverTextObject.GetComponent <Text>();

		GameObject restartTextObject = GameObject.FindGameObjectWithTag ("RestartText");
		restartText = restartTextObject.GetComponent <Text>();

		gameOver = false;
		crosshair = GameObject.Find("Crosshair");

		// A MonoBehavior function that takes a function name, when to first invoke it, and how often to repeat it
		InvokeRepeating ("SpawnAsteroid", 0, 10f);
	}

	void Update() {
		if (gameOver && Cardboard.SDK.CardboardTriggered) {
			// Reload the current level
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void SpawnAsteroid() {
		// Select a random point in a sphere
		Vector3 randomPosition = Random.onUnitSphere;

		// Move the point 20 units away and make sure it is in front of the camera
		Vector3 spawnPosition = new Vector3 (randomPosition.x * 20f, randomPosition.y * 20f, Mathf.Abs (randomPosition.z * 20f));

		// Corresponds to "no rotation"
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (asteroid, spawnPosition, spawnRotation);
	}

	public void GameOver() {
		CancelInvoke ("SpawnAsteroid");

		// Display Game Over and Restart text
		gameOverText.text = "Game Over";
		restartText.text = "Trigger to Restart";

		gameOver = true;
		Destroy (crosshair);
	}
}
