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
        LevelManager.Instance.currentLevel = 1;
        LevelLogicManager.Instance.PrepareLevel();
        SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL1);
    }

    public void LevelTwo()
    {
        if (PlayerManager.Instance.GetExperience().CurrentVal == LevelLogicManager.Instance.LEVEL_THRESHHOLD)
        {
            PlayerManager.Instance.badge = BadgeType.TEAM_LEAD;
            LevelManager.Instance.currentLevel = 2;
            LevelLogicManager.Instance.PrepareLevel();
            SceneTransitionManager.Instance.LoadScene(SceneEnum.LEVEL2);
        }
        else
        {
            PopupPanel.SetActive(true);
        }
    }

    public void CEOLevel()
    {
        if (PlayerManager.Instance.GetExperience().CurrentVal == LevelLogicManager.Instance.LEVEL_THRESHHOLD)
        {
            PlayerManager.Instance.badge = BadgeType.CEO;
            SceneTransitionManager.Instance.LoadScene(SceneEnum.EXIT);
        }
        else
        {
            PopupPanel.SetActive(true);
        }
    }

    public void HidePopup()
    {
        PopupPanel.SetActive(false);
    }

}
