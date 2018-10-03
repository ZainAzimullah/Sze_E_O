using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerManager.Instance.badge = BadgeType.GRADUATE;
	}

	public void StartGame() {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.INTRO_DIALOG);
    }

	public void ResumeGame() {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL1);
	}

	public void Options() {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.OPTIONS);
	}

	public void Quit() {
		Application.Quit();
	}

	public void MainMenu() {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.MAIN_MENU);
	}

}
