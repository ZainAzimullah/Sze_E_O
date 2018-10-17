using System;
﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BooleanMinigame : MonoBehaviour, IMinigame {

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
	public int experienceEarned = 25;

	// Player answers
	private string answer1;
	private string answer2;
	private string answer3;
	
	// Use this for initialization
	// makes sure all prompts are hidden at the start
	void Start() {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}

	// =======================================================================================================
	// these methods check if the user selected the correct drop downs in the debug minigame
	// if correct the correct answer method is called otherwise the incorrect method is called.
	
	public void CheckBooleanGame1()
	{
		RetrieveAnswers();
		if (answer1.Equals("A") & answer2.Equals("Not B") & answer3.Equals("Not C")) {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}
	
	public void CheckBooleanGame2() 
	{
		RetrieveAnswers();
		if (answer1.Equals("+") & answer2.Equals("+") & answer3.Equals("/")) {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}

	// third minigame is different due to only having one drop down
	public void CheckBooleanGame3()
	{
		answer1 = variable1.options[variable1.value].text;
		if (answer1.Equals("+")) {

			// the code in this block is a variation of the correct answer method.
			// only variable1 is disabled.
			quitButton.enabled = false;
			exitButton.enabled = false;
			runButton.enabled = false;
			variable1.enabled = false;

			correctPanel.gameObject.SetActive(true);
			earnedText.text = "You earned $" + moneyEarned + " and " + experienceEarned + " experience";
			// Updates the global experience of the player
			PlayerManager.Instance.UpdateExperience(experienceEarned);
            PlayerManager.Instance.UpdateMoney(moneyEarned);
        }
        else {
			// the code in this block is a variation of the incorrect answer method.
			// only variable1 is disabled.
			quitButton.enabled = false;
			exitButton.enabled = false;
			runButton.enabled = false;
			variable1.enabled = false;

			tryAgainPanel.gameObject.SetActive(true);
			// cannot lose money from minigame, thus gets a minimum of $20
			if (moneyEarned >= 20) {
				moneyEarned -= 20;
			}
		
		}


	}
	
	public void CheckBooleanGame4()
	{
		RetrieveAnswers();
		if (answer1.Equals("Green") & answer2.Equals("Not B") & answer3.Equals("true")) {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}
	// ===============================================================================================================

	// stores user input from game dropdown into the answer variables that will be checked.
	private void RetrieveAnswers()
	{
		answer1 = variable1.options[variable1.value].text;
		answer2 = variable2.options[variable2.value].text;
		answer3 = variable3.options[variable3.value].text;
	}

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
		runButton.enabled = false;
		variable1.enabled = false;
		variable2.enabled = false;
		variable3.enabled = false;
	}

	// reenables the buttons if user chooses to try again
	// or decides not to quit the minigame
	public void EnableButtons() {
		quitButton.enabled = true;
		exitButton.enabled = true;
		runButton.enabled = true;
		variable1.enabled = true;
		variable2.enabled = true;
		variable3.enabled = true;
	}

	// this method is also used for when user presses no on the exit prompt
	// if user decides not to quit or try again, it hides the responding prompt
	public void TryAgain() {
		areYouSurePanel.gameObject.SetActive(false);
		tryAgainPanel.gameObject.SetActive(false);
		// as minigame 3 has one drop down, makes sure to not touch variable 2 and 3 dropdowns
		// re enable miniagme buttons to let user try the minigame again.
		if (SceneManager.GetActiveScene().name.Equals("BooleanGame3")){
			quitButton.enabled = true;
			exitButton.enabled = true;
			runButton.enabled = true;
			variable1.enabled = true;
		} else {
			EnableButtons();
		}
	}

	// Indicates user has completed the minigame succefully and moves on to the scene
	public void Progress()
    {
        SceneName minigame = (SceneName) Enum.Parse(typeof(SceneName), SceneManager.GetActiveScene().name, true);
        GameLogicManager.Instance.MinigameDone(minigame);
    }

	// diplays the are you sure prompt, to confirm user action.
	public void ExitGame() {
		// as minigame 3 has one drop down, makes sure to not touch variable 2 and 3 dropdowns
		// disables all minigame buttons to let user try the minigame again.
		if (SceneManager.GetActiveScene().name.Equals("BooleanGame3"))
        {
            quitButton.enabled = false;
            exitButton.enabled = false;
            runButton.enabled = false;
            variable1.enabled = false;
        }
        else
        {
            DisableButtons();
        }    
		// display AreYouSureBox to confirm user action.
		areYouSurePanel.SetActive(true);
	}

	// if user confirms they want to quit, they return to level 1
	public void ExitYes() {
        SceneTransitionManager.Instance.LoadScene(SceneName.Level1);
	}


}