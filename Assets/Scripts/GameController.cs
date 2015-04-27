﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public delegate void GameEvent();
	public static event GameEvent GameOver;
	public static event GameEvent StartGame;

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
