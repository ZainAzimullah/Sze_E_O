using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour {


    public GameObject PopupPanel;


	// Use this for initialization
	void Start () {
        PopupPanel.SetActive(false);
	}

	public void GroundButton() {
		Debug.Log("START BUTTON IS WORKING");
		SceneManager.LoadScene("Gameplay");
	}

    public void LevelOne()
    {
   
        Debug.Log("LEVEL ONE BUTTON IS WORKING");
        SceneManager.LoadScene("Level1");
        
    }

    public void LevelTwo()
    {
        if (1 == 1)
        {
            PopupPanel.SetActive(true);
        }
        else
        {
            // Debug.Log("LEVEL TWO BUTTON IS WORKING");
            // SceneManager.LoadScene("Level2");
        }
    }

    public void HidePopup()
    {
        PopupPanel.SetActive(false);
    }

}
