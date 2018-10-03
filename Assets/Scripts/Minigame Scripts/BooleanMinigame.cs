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

	// Player answers
	private string _answer1;
	private string _answer2;
	private string _answer3;
	
	// Use this for initialization
	void Start() {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}
	
	public void CheckBooleanGame1()
	{
		RetrieveAnswers();
		if (_answer1.Equals("A") & _answer2.Equals("Not B") & _answer3.Equals("Not C")) {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}
	
	public void CheckBooleanGame2() 
	{
		RetrieveAnswers();
		if (_answer1.Equals("+") & _answer2.Equals("+") & _answer3.Equals("/")) {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}

	public void CheckBooleanGame3()
	{
		//TODO: Implement third Boolean game
		_answer1 = variable1.options[variable1.value].text;
		if (_answer1.Equals("+")) {

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
			// minimum experience earned is 2
			if (experienceEarned >= 4) {
				experienceEarned -= 2;
			}
		
		}


	}
	
	public void CheckBooleanGame4()
	{
		RetrieveAnswers();
		if (_answer1.Equals("Green") & _answer2.Equals("Not B") & _answer3.Equals("true")) {
			CorrectAnswer();
		} else {
			IncorrectAnswer();
		}
	}
	
	private void RetrieveAnswers()
	{
		_answer1 = variable1.options[variable1.value].text;
		_answer2 = variable2.options[variable2.value].text;
		_answer3 = variable3.options[variable3.value].text;
	}

	// Correct answer prompt
	private void CorrectAnswer()
	{
		disableButtons();
		correctPanel.gameObject.SetActive(true);
		earnedText.text = "You earned $"+ moneyEarned + " and " + experienceEarned +" experience";
		// Updates the global experience of the player
		PlayerManager.Instance.UpdateExperience(experienceEarned);
	}

	// Incorrect answer prompt
	private void IncorrectAnswer()
	{
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
		if (SceneManager.GetActiveScene().name.Equals("BooleanGame3")){
			quitButton.enabled = true;
			exitButton.enabled = true;
			runButton.enabled = true;
			variable1.enabled = true;
		} else {
			enableButtons();
		}
	}

	public void progress() {
        // TODO NEED TO SET TO PREVIOS SCREEN TO CONTINUE THE DIALOG
        SceneTransitionManager.Instance.LoadScene(SceneEnum.GREG_DIALOGUE_AFTER_MINIGAME);
    }

	public void exitGame() {
		disableButtons();
		areYouSurePanel.SetActive(true);
	}

	public void exitYes() {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL1);
	}


}