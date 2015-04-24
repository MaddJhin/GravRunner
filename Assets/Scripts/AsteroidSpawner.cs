using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject[] asteroids;
	public float startDelay, waveDelay, spawnDelay;
	public float waveCount;

	public float offset;

	private bool spawning;
	// Use this for initialization
	void Start () {
		spawning = true;
		StartCoroutine (SpawnAsteroid());
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
				Instantiate (asteroids[Random.Range(0, asteroids.Length)], position, Quaternion.identity);
				yield return new WaitForSeconds (spawnDelay);
			}

			yield return new WaitForSeconds (waveDelay);
		}
	}
}
