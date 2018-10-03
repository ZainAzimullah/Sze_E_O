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
        //Debug.Log("START BUTTON IS WORKING");
        //SceneManager.LoadScene("Gameplay");
        LevelManager.Instance.currentLevel = 0;
        SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL0);
	}

    public void LevelOne()
    {

        //Debug.Log("LEVEL ONE BUTTON IS WORKING");
        //SceneManager.LoadScene("Level1");
        LevelManager.Instance.currentLevel = 1;
        LevelLogicManager.Instance.PrepareLevel();
        SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL1);

        
    }

    public void LevelTwo()
    {
        if (PlayerManager.Instance.badge < BadgeType.TEAM_LEAD)
        {
            PopupPanel.SetActive(true);
        }
        else
        {
            // Debug.Log("LEVEL TWO BUTTON IS WORKING");
            // SceneManager.LoadScene("Level2");
            //LevelManager.Instance.currentLevel = 2;
        }
    }

    public void HidePopup()
    {
        PopupPanel.SetActive(false);
    }

}
