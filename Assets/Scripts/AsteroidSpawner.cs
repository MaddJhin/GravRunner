using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject startingAsteroids;
	public GameObject[] asteroids;
	public float startDelay, waveDelay, spawnDelay;
	public float waveCount;
	public float offset;

	private bool spawning;
	private GameObject asteroidField;
	private IEnumerator coroutine;

	void OnEnable () {
		GameController.StartGame += StartGame;
		GameController.GameOver += GameOver;
	}

	void OnDisable () {
		GameController.StartGame -= StartGame;
		GameController.GameOver -= GameOver;
	}

	void Start () {
		coroutine = SpawnAsteroid();
		StartGame ();
	}

	IEnumerator SpawnAsteroid(){
		yield return new WaitForSeconds (startDelay);
		while (spawning)
		{
			for (int i = 0; i < waveCount; i++)
			{
				Vector3 position = new Vector3 (transform.position.x, 
				                                transform.position.y + Random.Range(-offset, offset), 
				                                transform.position.z);
				GameObject asteroid = Instantiate (asteroids[Random.Range(0, asteroids.Length)], position, Quaternion.identity) as GameObject;
				asteroid.transform.parent = asteroidField.transform;;
				yield return new WaitForSeconds (spawnDelay);
			}

			yield return new WaitForSeconds (waveDelay);
		}
	}

	void StartGame() {
		if (asteroidField != null)
		{
			Destroy(asteroidField);
		}
		asteroidField = new GameObject ("Asteroid Field");
		spawning = true;
		StartCoroutine (coroutine);
	}

	void GameOver() {
		StopCoroutine(coroutine);

	}
}
