using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public void LoadGame() {
		Application.LoadLevel(1);
		GameController.instance.TriggerStartGame();
	}

	public void LoadMenue() {
		GameController.instance.TriggerGameOver();
		Application.LoadLevel (0);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
