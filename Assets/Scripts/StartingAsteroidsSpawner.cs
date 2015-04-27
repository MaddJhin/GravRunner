using UnityEngine;
using System.Collections;

public class StartingAsteroidsSpawner : MonoBehaviour {

	public GameObject startingAsteroids;

	private GameObject startingField;

	void OnEnable() {
		GameController.StartGame += StartGame;
	}

	void Start() {
		StartGame();
	}

	void StartGame() {
		if (startingField != null)
		{
			Destroy(startingField);
		}
		startingField = Instantiate (startingAsteroids, new Vector3 (22.57f, 2.78f, -8.35f), Quaternion.identity) as GameObject;
	}
}
