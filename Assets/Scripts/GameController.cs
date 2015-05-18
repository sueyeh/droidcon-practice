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
		InvokeRepeating ("SpawnAsteroid", 0, 10f);
		GameObject gameOverTextObject = GameObject.FindGameObjectWithTag ("GameOverText");
		gameOverText = gameOverTextObject.GetComponent <Text>();

		GameObject restartTextObject = GameObject.FindGameObjectWithTag ("RestartText");
		restartText = restartTextObject.GetComponent <Text>();

		crosshair = GameObject.Find("Crosshair");

		gameOver = false;
	}

	void Update() {
		if (gameOver && Cardboard.SDK.CardboardTriggered) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void SpawnAsteroid() {
		Vector3 randomPosition = Random.onUnitSphere;
		Vector3 spawnPosition = new Vector3 (randomPosition.x * 20f, randomPosition.y * 20f, randomPosition.z * 20f);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (asteroid, spawnPosition, spawnRotation);
	}

	public void GameOver() {
		CancelInvoke ("SpawnAsteroid");
		gameOverText.text = "Game Over";
		restartText.text = "Trigger to Restart";
		gameOver = true;
		Destroy (crosshair);
	}
}
