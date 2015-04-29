using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text scoreText;
	public Text noticeText;
	public Button restartButton;
	public Button exitButton;
	public GameObject mainMenu;
	public int scoreMultiplier = 2;

	private bool paused;
	private bool gameOver;
	private int score = 0;
	private float startTime;

	void OnEnable() {
		GameController.StartGame += StartGame;
		GameController.GameOver += GameOver;
	}

	void OnDisable() {
		GameController.StartGame -= StartGame;
		GameController.GameOver -= GameOver;
	}

	void Start () {
		StartGame();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused)
		{
			Debug.Log("Game Paused");
			PauseGame();
		}
		else if (Input.GetKeyDown (KeyCode.Escape) && paused)
		{
			Debug.Log("Game Resumed");
			ResumeGame();
		}

		score = Mathf.RoundToInt((Time.time - startTime) * scoreMultiplier);

		if (!gameOver)
		{
			scoreText.text = "Score: " + score;
		}
	}

	void PauseGame() {
		paused = true;
		noticeText.text = "Game Paused";
		noticeText.enabled = true;
		exitButton.interactable = true;
		restartButton.interactable = true;
		Time.timeScale = 0;
	}

	void ResumeGame() {
		paused = false;
		noticeText.enabled = false;
		exitButton.interactable = false;
		restartButton.interactable = false;
		Time.timeScale = 1;
	}

	void StartGame () {
		startTime = Time.time;
		gameOver = false;
		ResumeGame();
	}

	void GameOver() {
		gameOver = true;
		noticeText.text = "Game Over";
		noticeText.enabled = true;
		exitButton.interactable = true;
		restartButton.interactable = true;
		Debug.Log("Game Over");
	}
}
