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
	void Start () {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}

	//================================================================================================================================

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
		DisableButtons();
		correctPanel.gameObject.SetActive(true);
		earnedText.text = "You earned $" + moneyEarned + " and " + experienceEarned + " experience";
		// Updates the global experience of the player
		PlayerManager.Instance.UpdateExperience(experienceEarned);
	}

	// Incorrect answer prompt
	private void IncorrectAnswer() {
		DisableButtons();
		tryAgainPanel.gameObject.SetActive(true);
		// cannot lose money from minigame
		if (moneyEarned >= 20) {
			moneyEarned -= 20;
		}
	}

	public void DisableButtons() {
		quitButton.enabled = false;
		exitButton.enabled = false;
		checkButton.enabled = false;
		answer.enabled = false;
	}

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

	public void Progress() {
		//SceneName minigame = (SceneName)Enum.Parse(typeof(SceneName), SceneManager.GetActiveScene().name, true);
		//GameLogicManager.Instance.MinigameDone(minigame);
	}

	public void ExitGame() {
		DisableButtons();
		areYouSurePanel.SetActive(true);
	}

	public void ExitYes() {
		//SceneTransitionManager.Instance.LoadScene(SceneName.Level1);
	}

}
