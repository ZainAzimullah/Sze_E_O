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
		//Debug.Log("START BUTTON IS WORKING");
        //SceneManager.LoadScene("Gameplay");
        SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL0);
    }

	public void ResumeGame() {

		//Debug.Log("RESUME BUTTON IS WORKING");
        //SceneManager.LoadScene("Gameplay");
        SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL1);
	}

	public void Options() {

        //Debug.Log("OPTIONS BUTTON IS WORKING");
        //SceneManager.LoadScene("Options");
        SceneTransitionManager.Instance.LoadScene(SceneEnum.OPTIONS);
	}

	public void Quit() {
		Application.Quit();
	}

	public void MainMenu() {
        //SceneManager.LoadScene("MainMenu");
        SceneTransitionManager.Instance.LoadScene(SceneEnum.MAIN_MENU);
	}

}
