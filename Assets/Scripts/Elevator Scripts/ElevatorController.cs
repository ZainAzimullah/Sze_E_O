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
        LevelManager.Instance.currentLevel = 0;
        LevelLogicManager.Instance.PrepareForRevisit();
        SceneTransitionManager.Instance.LoadScene(SceneEnum.Level0);
	}

    public void LevelOne()
    {
        LevelManager.Instance.currentLevel = 1;
        LevelLogicManager.Instance.PrepareForRevisit();
        if (LevelLogicManager.Instance.GetMinigameRecorder() == null)
        {
            LevelLogicManager.Instance.PrepareForFirstVisit();
        }
        SceneTransitionManager.Instance.LoadScene(SceneEnum.Level1);
    }

    public void LevelTwo()
    {
        if (PlayerManager.Instance.GetExperience().CurrentVal == LevelLogicManager.Instance.LEVEL_THRESHHOLD || PlayerManager.Instance.badge >= BadgeType.TEAM_LEAD)
        {
            if (PlayerManager.Instance.badge < BadgeType.TEAM_LEAD)
            {
                PlayerManager.Instance.badge = BadgeType.TEAM_LEAD;
                PlayerManager.Instance.Refresh();
                LevelLogicManager.Instance.PrepareForFirstVisit();
            }
            else
            {
                LevelLogicManager.Instance.PrepareForRevisit();
            }

            LevelManager.Instance.currentLevel = 2;
            SceneTransitionManager.Instance.LoadScene(SceneEnum.Level2);
        }
        else
        {
            PopupPanel.SetActive(true);
        }
    }

    public void LevelThree()
    {
        if (PlayerManager.Instance.GetExperience().CurrentVal == LevelLogicManager.Instance.LEVEL_THRESHHOLD || PlayerManager.Instance.badge >= BadgeType.MANAGER)
        {
            if (PlayerManager.Instance.badge < BadgeType.MANAGER)
            {
                PlayerManager.Instance.badge = BadgeType.MANAGER;
                PlayerManager.Instance.Refresh();
                LevelLogicManager.Instance.PrepareForFirstVisit();
            }
            else
            {
                LevelLogicManager.Instance.PrepareForRevisit();
            }

            LevelManager.Instance.currentLevel = 3;
            SceneTransitionManager.Instance.LoadScene(SceneEnum.Level3);
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
            SceneTransitionManager.Instance.LoadScene(SceneEnum.ExitScreen);
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
