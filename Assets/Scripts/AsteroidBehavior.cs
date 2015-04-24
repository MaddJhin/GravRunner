using UnityEngine;
using System.Collections;

public class AsteroidBehavior : MonoBehaviour {

	public float scaleMin, scaleMax;
	public float tumbleMin, tumbleMax;

	private float scaleFactor;
	private Vector3 scale;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		scaleFactor = Random.Range(scaleMin, scaleMax);
		scale = new Vector3 (scaleFactor, scaleFactor, scaleFactor);

		transform.localScale = scale;

		Tumble();
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
			GameController.instance.GameOver();
			Destroy (this.gameObject);
		}
	}
}
