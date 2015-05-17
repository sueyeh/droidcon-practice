using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	private GameController gameController;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();

	}
	
	void OnTriggerEnter (Collider other)
	{
		Destroy (gameObject);
		gameController.GameOver();
	}
}