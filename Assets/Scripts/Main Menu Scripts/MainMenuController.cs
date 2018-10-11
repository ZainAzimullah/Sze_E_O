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
        SceneTransitionManager.Instance.LoadScene(SceneEnum.IntroDialogue);
    }

	public void ResumeGame() {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.Level1);
	}

	public void Options() {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.Options);
	}

	public void Quit() {
		Application.Quit();
	}

	public void MainMenu() {
        //Check whether it's the first time to get into MainMenu
        if (PlayerManager.Instance.GetNumberofTrackers() > 0)
        {
            PlayerManager.Instance.ReinitializeTracker();
        }
        //Avoid tutorial dialogue load to the current level
        LevelManager.Instance.currentLevel = 0;
        SceneTransitionManager.Instance.LoadScene(SceneEnum.MainMenu);
	}

}
