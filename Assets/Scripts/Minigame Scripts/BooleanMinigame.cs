using System;
﻿using UnityEngine;
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
	public int experienceEarned = 25;

	// Player answers
	private string answer1;
	private string answer2;
	private string answer3;
	
	// Use this for initialization
	void Start() {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}
	
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

	public void CheckBooleanGame3()
	{
		//TODO: Implement third Boolean game
		answer1 = variable1.options[variable1.value].text;
		if (answer1.Equals("+")) {

			quitButton.enabled = false;
			exitButton.enabled = false;
			runButton.enabled = false;
			variable1.enabled = false;

			correctPanel.gameObject.SetActive(true);
			earnedText.text = "You earned $" + moneyEarned + " and " + experienceEarned + " experience";
			// Updates the global experience of the player
			PlayerManager.Instance.UpdateExperience(experienceEarned);

		} else {

			quitButton.enabled = false;
			exitButton.enabled = false;
			runButton.enabled = false;
			variable1.enabled = false;

			tryAgainPanel.gameObject.SetActive(true);
			// cannot lose money from minigame
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
	
	private void RetrieveAnswers()
	{
		answer1 = variable1.options[variable1.value].text;
		answer2 = variable2.options[variable2.value].text;
		answer3 = variable3.options[variable3.value].text;
	}

	// Correct answer prompt
	private void CorrectAnswer()
	{
		DisableButtons();
		correctPanel.gameObject.SetActive(true);
		earnedText.text = "You earned $"+ moneyEarned + " and " + experienceEarned +" experience";
        // Updates the global experience of the player
        Debug.Log("Before update: " + PlayerManager.Instance.GetExperience().CurrentVal);
		PlayerManager.Instance.UpdateExperience(experienceEarned);
        Debug.Log("After update: " + PlayerManager.Instance.GetExperience().CurrentVal);
    }

    // Incorrect answer prompt
    private void IncorrectAnswer()
	{
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
		runButton.enabled = false;
		variable1.enabled = false;
		variable2.enabled = false;
		variable3.enabled = false;
	}

	public void EnableButtons() {
		quitButton.enabled = true;
		exitButton.enabled = true;
		runButton.enabled = true;
		variable1.enabled = true;
		variable2.enabled = true;
		variable3.enabled = true;
	}

	//this method is also used for when user presses no on the exit prompt
	public void TryAgain() {
		areYouSurePanel.gameObject.SetActive(false);
		tryAgainPanel.gameObject.SetActive(false);
		if (SceneManager.GetActiveScene().name.Equals("BooleanGame3")){
			quitButton.enabled = true;
			exitButton.enabled = true;
			runButton.enabled = true;
			variable1.enabled = true;
		} else {
			EnableButtons();
		}
	}

	public void Progress()
    {
        SceneName minigame = (SceneName) Enum.Parse(typeof(SceneName), SceneManager.GetActiveScene().name, true);
        GameLogicManager.Instance.MinigameDone(minigame);
    }

	public void ExitGame() {
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
		areYouSurePanel.SetActive(true);
	}

	public void ExitYes() {
        SceneTransitionManager.Instance.LoadScene(SceneName.Level1);
	}


}