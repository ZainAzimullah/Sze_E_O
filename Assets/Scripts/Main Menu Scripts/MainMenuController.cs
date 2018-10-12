using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
	public void StartGame() {
        LevelManager.Instance.currentLevel = 0;
        PlayerManager.Instance.UpdateExperience(LevelLogicManager.Instance.LEVEL_THRESHHOLD);
        LevelLogicManager.Instance.PrepareForFirstVisit();
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

        //To Ensure nothing is frozen
        Time.timeScale = 1;
        LevelUIManager.Instance.isCamFreeze = false;

        SceneTransitionManager.Instance.LoadScene(SceneEnum.MainMenu);
	}

}
