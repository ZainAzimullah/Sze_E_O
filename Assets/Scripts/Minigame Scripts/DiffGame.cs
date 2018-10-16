using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffGame : MonoBehaviour, IMinigame {

	// game objects
	public Button quitButton;
	public Button exitButton;
	public Button runButton;
	public GameObject correctPanel;
	public GameObject gamePanel;
	public GameObject tryAgainPanel;
	public GameObject areYouSurePanel;
	public Text earnedText;

	// Code line buttons
	public Button Line1Button;
	public Button Line2Button;
	public Button Line3Button;
	public Button Line4Button;
	public Button Line5Button;
	public Button Line6Button;
	public Button Line7Button;
	public Button Line8Button;

	// booleans to check if the 
	private boolean Line1Answer;
	private boolean Line2Answer;
	private boolean Line3Answer;
	private boolean Line4Answer;
	private boolean Line5Answer;
	private boolean Line6Answer;
	private boolean Line7Answer;
	private boolean Line8Answer;


	// game money and experience variables
	public int moneyEarned = 100;
	public int experienceEarned = 25;


	public void Progress() {
		throw new System.NotImplementedException();
	}

	// Use this for initialization
	void Start () {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}
	
}
