using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerManager.instance().badge = BadgeType.GRADUATE;
	}

	public void StartGame() {
		Debug.Log("START BUTTON IS WORKING");
		SceneManager.LoadScene("Gameplay");
	}

	public void ResumeGame() {

		Debug.Log("RESUME BUTTON IS WORKING");
		SceneManager.LoadScene("Gameplay");
	}

	public void Options() {

		Debug.Log("OPTIONS BUTTON IS WORKING");
		SceneManager.LoadScene("Options");
	}

	public void Quit() {

		Debug.Log("QUIT BUTTON IS WORKING");
		Application.Quit();
	}

	public void MainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

}
