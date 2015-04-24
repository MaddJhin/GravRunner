using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject player;

	private bool gameOver;
	private bool restart;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		gameOver = false;
		restart = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	public void GameOver() {
		player.GetComponent<Rigidbody2D>().isKinematic = true;
		player.GetComponent<Renderer>().enabled = false;
		player.SetActive(false);
	}
}
