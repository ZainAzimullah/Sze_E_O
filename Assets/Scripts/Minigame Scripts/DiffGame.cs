using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	public Button line1Button;
	public Button line2Button;
	public Button line3Button;
	public Button line4Button;
	public Button line5Button;
	public Button line6Button;
	public Button line7Button;
	public Button line8Button;

	// booleans to check if the 
	private bool line1Answer = false;
	private bool line2Answer = false;
	private bool line3Answer = false;
	private bool line4Answer = false;
	private bool line5Answer = false;
	private bool line6Answer = false;
	private bool line7Answer = false;
	private bool line8Answer = false;


	// game money and experience variables
	public int moneyEarned = 100;
	public int experienceEarned = 25;

    // color variable
    public Color bgColor = new Color((float)0.3, (float)0.29, (float)0.3);


    public void Progress() {
        SceneName sceneName = (SceneName) Enum.Parse(typeof(SceneName), SceneManager.GetActiveScene().name, true);
        GameLogicManager.Instance.MinigameDone(sceneName);
	}

	// Use this for initialization
	void Start () {
		correctPanel.SetActive(false);
		tryAgainPanel.SetActive(false);
		areYouSurePanel.SetActive(false);
	}

    // Correct answer prompt
    private void CorrectAnswer()
    {
        DisableButtons();
        correctPanel.gameObject.SetActive(true);
        earnedText.text = "You earned $" + moneyEarned + " and " + experienceEarned + " experience";
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
        Debug.Log("Got In");
        // cannot lose money from minigame
        if (moneyEarned >= 20)
        {
            Debug.Log("Money Before: " + moneyEarned);
            moneyEarned -= 20;
            Debug.Log("Money After: " + moneyEarned);
        }
    }

    public void DisableButtons()
    {
        //quitButton.enabled = false;
        //exitButton.enabled = false;
        runButton.enabled = false;
        line1Button.enabled = false;
        line2Button.enabled = false;
        line3Button.enabled = false;
        line4Button.enabled = false;
        line5Button.enabled = false;
        line6Button.enabled = false;
        line7Button.enabled = false;
        line8Button.enabled = false;


    }

    public void EnableButtons()
    {
        //quitButton.enabled = true;
        //exitButton.enabled = true;
        runButton.enabled = true;
        line1Button.enabled = true;
        line2Button.enabled = true;
        line3Button.enabled = true;
        line4Button.enabled = true;
        line5Button.enabled = true;
        line6Button.enabled = true;
        line7Button.enabled = true;
        line8Button.enabled = true;

        line1Button.GetComponent<Image>().color = bgColor;
        line2Button.GetComponent<Image>().color = bgColor;
        line3Button.GetComponent<Image>().color = bgColor;
        line4Button.GetComponent<Image>().color = bgColor;
        line5Button.GetComponent<Image>().color = bgColor;
        line6Button.GetComponent<Image>().color = bgColor;
        line7Button.GetComponent<Image>().color = bgColor;
        line8Button.GetComponent<Image>().color = bgColor;

        line1Answer = false;
        line2Answer = false;
        line3Answer = false;
        line4Answer = false;
        line5Answer = false;
        line6Answer = false;
        line7Answer = false;
        line8Answer = false;
        
    }

    //this method is also used for when user presses no on the exit prompt
    public void TryAgain()
    {
        
        areYouSurePanel.gameObject.SetActive(false);
        tryAgainPanel.gameObject.SetActive(false);
        Debug.Log("after activating false");
        EnableButtons();
    }


    //==========================================================================================================

    public void CheckDiffGame1()
    {
        //Line 3, 4, 7, 8
        if (line1Answer == false && line4Answer == true && line7Answer == true
            && line2Answer == false && line3Answer == true && line5Answer == false
            && line6Answer == false && line8Answer == true)
        {

            CorrectAnswer();
        }
        else
        {
            Debug.Log("before activating false");
            IncorrectAnswer();
        }

    }
    //=========================================================================================================

    public void CheckDiffGame2() {
        //Line 1, 4, 7
        if (line1Answer == true && line4Answer == true && line7Answer == true 
            && line2Answer == false && line3Answer == false && line5Answer == false 
            && line6Answer == false && line8Answer == false)
        {

            CorrectAnswer();
        } else
        {
            Debug.Log("before activating false");
            IncorrectAnswer();
        }

    }


    //==========================================================================================================

    public void CheckDiffGame3()
    {
        //Line 1, 4, 5, 6
        if (line1Answer == true && line4Answer == true && line7Answer == false
            && line2Answer == false && line3Answer == false && line5Answer == true
            && line6Answer == true && line8Answer == false)
        {

            CorrectAnswer();
        }
        else
        {
            Debug.Log("before activating false");
            IncorrectAnswer();
        }

    }

    //==========================================================================================================

    public void CheckDiffGame4()
    {
        //Line 2,4,6,7,8
        if (line1Answer == false && line4Answer == true && line7Answer == true
            && line2Answer == true && line3Answer == false && line5Answer == false
            && line6Answer == true && line8Answer == true)
        {

            CorrectAnswer();
        }
        else
        {
            Debug.Log("before activating false");
            IncorrectAnswer();
        }

    }

    //==========================================================================================================
    // BUTTON TOGGLING CODE

    public void OnLine1Click (){ 
        if (line1Answer)
        {
            line1Answer = false;
            line1Button.GetComponent<Image>().color = new Color((float)0.3, (float)0.29, (float)0.3);
        }
        else {
            line1Answer = true;
            line1Button.GetComponent<Image>().color = Color.gray;
        }
    }

    public void OnLine2Click()
    {
        if (line2Answer)
        {
            line2Answer = false;
            line2Button.GetComponent<Image>().color = new Color((float)0.3,(float)0.29,(float)0.3);

        }
        else
        {
            line2Answer = true;
            line2Button.GetComponent<Image>().color = Color.gray;
        }
    }

    public void OnLine3Click()
    {
        if (line3Answer)
        {
            line3Answer = false;
            line3Button.GetComponent<Image>().color = new Color((float)0.3, (float)0.29, (float)0.3);
        }
        else
        {
            line3Answer = true;
            line3Button.GetComponent<Image>().color = Color.gray;
        }
    }


    public void OnLine4Click()
    {
        if (line4Answer)
        {
            line4Answer = false;
            line4Button.GetComponent<Image>().color = new Color((float)0.3, (float)0.29, (float)0.3);
        }
        else
        {
            line4Answer = true;
            line4Button.GetComponent<Image>().color = Color.gray;
        }
    }

    public void OnLine5Click()
    {
        if (line5Answer)
        {
            line5Answer = false;
            line5Button.GetComponent<Image>().color = new Color((float)0.3, (float)0.29, (float)0.3);
        }
        else
        {
            line5Answer = true;
            line5Button.GetComponent<Image>().color = Color.gray;
        }
    }

    public void OnLine6Click()
    {
        if (line6Answer)
        {
            line6Answer = false;
            line6Button.GetComponent<Image>().color = new Color((float)0.3, (float)0.29, (float)0.3);
        }
        else
        {
            line6Answer = true;
            line6Button.GetComponent<Image>().color = Color.gray;
        }
    }

    public void OnLine7Click()
    {
        if (line7Answer)
        {
            line7Answer = false;
            line7Button.GetComponent<Image>().color = new Color((float)0.3, (float)0.29, (float)0.3);
        }
        else
        {
            line7Answer = true;
            line7Button.GetComponent<Image>().color = Color.gray;
        }
    }

    public void OnLine8Click()
    {
        if (line8Answer)
        {
            line8Answer = false;
            line8Button.GetComponent<Image>().color = new Color((float)0.3, (float)0.29, (float)0.3);
        }
        else
        {
            line8Answer = true;
            line8Button.GetComponent<Image>().color = Color.gray;
        }
    }
    //=========================================================================================================
}
