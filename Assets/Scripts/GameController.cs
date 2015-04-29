using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public delegate void GameEvent();
	public static event GameEvent GameOver;
	public static event GameEvent StartGame;

	public static GameController instance;
	public GameObject player;

	void Awake() {
		instance = this;
	}

	void Start () {
			player = GameObject.FindGameObjectWithTag ("Player");
	}

	public void TriggerGameOver() {
		if (GameOver != null)
		{
			GameOver();
		}
	}

	public void TriggerStartGame () {
		if (StartGame != null)
		{
			StartGame();
		}
	}
}
