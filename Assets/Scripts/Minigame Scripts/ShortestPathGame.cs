using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShortestPathGame : MonoBehaviour, IMinigame {

	// game objects
	public InputField answer;
	public Button quitButton;
	public Button exitButton;
	public Button checkButton;
	public GameObject correctPanel;
	public GameObject gamePanel;
	public GameObject tryAgainPanel;
	public GameObject areYouSurePanel;
	public Text earnedText;

	// game money and experience variables
	public int moneyEarned = 100;
	public int experienceEarned = 25;

	// Use this for initialization
	// makes sure all prompts are hidden.
	void Start () {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}

	//================================================================================================================================
	// these CheckShortestPath methods checks if the user entered the correct shortest path value
	// displays the correct prompt if they are correct, otherwise the incorrect prompt is displayed

	public void CheckShortestPath1() {
		if (answer.text == "15") {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}

	public void CheckShortestPath2() {
		if (answer.text == "12") {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}

	public void CheckShortestPath3() {
		if (answer.text == "33") {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}

	public void CheckShortestPath4() {
		if (answer.text == "21") {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}

	//================================================================================================================================

	// Correct answer prompt
	private void CorrectAnswer() {
		// first diable the minigame buttons to stop user action
		DisableButtons();
		// display the prompt indicating the user is correct
		correctPanel.gameObject.SetActive(true);
		// set text of the prompt based on how much money and exp is earned
		earnedText.text = "You earned $" + moneyEarned + " and " + experienceEarned + " experience";
		// Updates the global experience and money of the player
		PlayerManager.Instance.UpdateExperience(experienceEarned);
		PlayerManager.Instance.UpdateMoney(moneyEarned);
	}

	// Incorrect answer prompt
	private void IncorrectAnswer() {
		// first diable the minigame buttons to stop user action
		DisableButtons();
		// display prompty indication user was wrong, gives option to try again.
		tryAgainPanel.gameObject.SetActive(true);
		// cannot lose money from minigame, thus must be atleast $20
		if (moneyEarned >= 20) {
			// lose 20 dollars each time the player gets the task wrong
			moneyEarned -= 20;
		}
	}

	// Disables all minigame buttons to stop users from pressing it while
	// dealing with prompts.
	public void DisableButtons() {
		quitButton.enabled = false;
		exitButton.enabled = false;
		checkButton.enabled = false;
		answer.enabled = false;
	}

	// reenables the buttons if user chooses to try again
	// or decides not to quit the minigame
	public void EnableButtons() {
		quitButton.enabled = true;
		exitButton.enabled = true;
		checkButton.enabled = true;
		answer.enabled = true;
	}

	//this method is also used for when user presses no on the exit prompt
	public void TryAgain() {
		areYouSurePanel.gameObject.SetActive(false);
		tryAgainPanel.gameObject.SetActive(false);
		EnableButtons();
	}

	// Indicates user has completed the minigame succefully and moves on to the scene
	public void Progress() {
		SceneName minigame = (SceneName)Enum.Parse(typeof(SceneName), SceneManager.GetActiveScene().name, true);
		GameLogicManager.Instance.MinigameDone(minigame);
	}

	// diplays the are you sure prompt, to confirm user action.
	public void ExitGame() {
		DisableButtons();
		areYouSurePanel.SetActive(true);
	}

	// if user confirms they want to quit, they return to level 3
	public void ExitYes() {
		SceneTransitionManager.Instance.LoadScene(SceneName.Level3);
	}

}
