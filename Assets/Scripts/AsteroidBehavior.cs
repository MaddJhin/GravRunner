using UnityEngine;
using System.Collections;

public class AsteroidBehavior : MonoBehaviour {

	public float scaleMin, scaleMax;
	public float tumbleMin, tumbleMax;

	private float scaleFactor;
	private Vector3 scale;
	private Rigidbody2D rb;

	void OnEnable() {
		GameController.StartGame += StartGame;
	}

	void OnDisable() {
		GameController.StartGame -= StartGame;
	}

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		StartGame();
	}

	void Tumble (){
		if (Random.value <= 0.5)
		{
			rb.AddTorque (Random.Range (tumbleMin, tumbleMax));
		}
		else
		{
			rb.AddTorque ((Random.Range (tumbleMin, tumbleMax)) * -1);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
		{
			GameController.instance.TriggerGameOver();
			Destroy (this.gameObject);
		}
	}

	void StartGame() {
		scaleFactor = Random.Range(scaleMin, scaleMax);
		scale = new Vector3 (scaleFactor, scaleFactor, scaleFactor);
		
		transform.localScale = scale;
		
		Tumble();
	}
}
