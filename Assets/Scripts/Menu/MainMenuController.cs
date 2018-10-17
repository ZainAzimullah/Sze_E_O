using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void StartGame() {
		// start at level 0
        LevelManager.Instance.currentLevel = 0;
		// goes to dialog to teach user game.
        PlayerManager.Instance.mode = PlayerMode.TUTORIAL;

        // Restart if they finished the game last time
        if (PlayerManager.Instance.badge == BadgeType.CEO)
        {
			// reset game progress.
            PlayerManager.Instance.Reset();
        }
        GameLogicManager.Instance.PrepareForFirstVisit();
        SceneTransitionManager.Instance.LoadScene(SceneName.IntroDialogue);
    }

	// closes the application
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

        //To Ensure nothing is frozen
        Time.timeScale = 1;
        LevelUIManager.Instance.isCamFreeze = false;

        SceneTransitionManager.Instance.LoadScene(SceneName.MainMenu);
	}

}
