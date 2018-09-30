using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BooleanMinigame : MonoBehaviour {

	// game objects
	public Dropdown variable1;
	public Dropdown variable2;
	public Dropdown variable3;
	public Button quitButton;
	public Button exitButton;
	public Button runButton;
	public GameObject correctPanel;
	public GameObject gamePanel;
	public GameObject tryAgainPanel;
	public GameObject areYouSurePanel;
	public Text earnedText;

	// game money and experience variables
	public int moneyEarned = 100;
	public int experienceEarned = 10;

	// Use this for initialization
	void Start() {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}

	public void checkCode() {
		var var1Val = variable1.value;
		var var2Val = variable2.value;
		var var3Val = variable3.value;
		var answer1 = variable1.options[var1Val].text;
		var answer2 = variable2.options[var2Val].text;
		var answer3 = variable3.options[var3Val].text;
		if (answer1.Equals("A") & answer2.Equals("Not B") & answer3.Equals("Not C")) {
			disableButtons();
			correctPanel.gameObject.SetActive(true);
			earnedText.text = "You earned $"+ moneyEarned + " and " + experienceEarned +" experience";
		} else {
			disableButtons();
			tryAgainPanel.gameObject.SetActive(true);
			// cannot lose money from minigame
			if (moneyEarned >= 20) {
				moneyEarned -= 20;
			}
			// minimum experience earned is 2
			if (experienceEarned >= 4) {
				experienceEarned -= 2;
			}
		}

	}

	public void disableButtons() {
		quitButton.enabled = false;
		exitButton.enabled = false;
		runButton.enabled = false;
		variable1.enabled = false;
		variable2.enabled = false;
		variable3.enabled = false;
	}

	public void enableButtons() {
		quitButton.enabled = true;
		exitButton.enabled = true;
		runButton.enabled = true;
		variable1.enabled = true;
		variable2.enabled = true;
		variable3.enabled = true;
	}

	//this method is also used for when user presses no on the exit prompt
	public void tryAgain() {
		areYouSurePanel.gameObject.SetActive(false);
		tryAgainPanel.gameObject.SetActive(false);
		enableButtons();
	}

	public void progress() {
		// TODO NEED TO SET TO PREVIOS SCREEN TO CONTINUE THE DIALOG
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void exitGame() {
		disableButtons();
		areYouSurePanel.SetActive(true);
	}

	public void exitYes() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneTransitionManager.GetInstance().LoadScene(SceneEnum.LEVEL1);
	}


}
