using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject asteroidExplosion;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
		{
			Instantiate (playerExplosion, other.transform.position, Quaternion.identity);
			Instantiate (asteroidExplosion, this.transform.position, Quaternion.identity);
			GameController.instance.TriggerGameOver();
			Destroy (this.gameObject);
		}
	}
}
