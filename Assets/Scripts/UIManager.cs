using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text scoreText;
	public Text noticeText;
	public Button restartButton;
	public Button exitButton;
	public GameObject mainMenu;

	private bool paused;

	void OnEnable() {
		GameController.StartGame += StartGame;
		GameController.GameOver += GameOver;
	}

	// Use this for initialization
	void Start () {
		ResumeGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused)
		{
			PauseGame();
		}
		else if (Input.GetKeyDown (KeyCode.Escape) && paused)
		{
			ResumeGame();
		}
	}

	void PauseGame() {
		paused = true;
		noticeText.text = "Game Paused";
		noticeText.enabled = true;
		exitButton.gameObject.SetActive (true);
		restartButton.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	void ResumeGame() {
		paused = false;
		Time.timeScale = 1;
		noticeText.enabled = false;
		exitButton.gameObject.SetActive (false);
		restartButton.gameObject.SetActive(false);

	}

	void StartGame () {
		ResumeGame();
	}

	void GameOver() {
		noticeText.text = "Game Over";
		noticeText.enabled = true;
		exitButton.gameObject.SetActive (true);
		restartButton.gameObject.SetActive(true);
	}
}
