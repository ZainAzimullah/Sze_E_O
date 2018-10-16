using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour {


    public GameObject PopupPanel;


    // Use this for initialization
    void Start()
    {
        PopupPanel.SetActive(false);
    }

    public void GroundButton()
    {
        CheckVisit(BadgeType.NEW_PLAYER);
    }

    public void LevelOne()
    {
        CheckVisit(BadgeType.GRADUATE);
    }

    public void LevelTwo()
    {
        CheckVisit(BadgeType.TEAM_LEAD);
    }

    public void LevelThree()
    {
        CheckVisit(BadgeType.MANAGER);
    }

    public void WinGame()
    {
        CheckVisit(BadgeType.CEO);
    }

    private void CheckVisit(BadgeType badgeType)
    {
        if (PlayerManager.Instance.badge >= badgeType)
        {
            LevelManager.Instance.currentLevel = (int)badgeType;
            GameLogicManager.Instance.PrepareForRevisit();
        } else if (PlayerManager.Instance.badge == BadgeType.NEW_PLAYER && badgeType == BadgeType.GRADUATE)
        {
            LevelManager.Instance.currentLevel = (int)badgeType;
            // Promote badge
            PlayerManager.Instance.badge = badgeType;

            // Check if they won the game
            if (PlayerManager.Instance.badge == BadgeType.CEO)
            {
                PlayerManager.Instance.Refresh();
                SceneTransitionManager.Instance.LoadScene(SceneName.ExitScreen);
            }

            PlayerManager.Instance.Refresh();
            GameLogicManager.Instance.PrepareForFirstVisit();
        } else if (PlayerManager.Instance.GetExperience().CurrentVal == GameLogicManager.Instance.LEVEL_THRESHOLD
                    && badgeType == PlayerManager.Instance.badge + 1)
        {
            LevelManager.Instance.currentLevel = (int)badgeType;
            // Promote badge
            PlayerManager.Instance.badge = badgeType;
            PlayerManager.Instance.Refresh();
            GameLogicManager.Instance.PrepareForFirstVisit();
        } else
        {
            PopupPanel.SetActive(true);
            return;
        }

        SceneTransitionManager.Instance.LoadScene(badgeType.GetAssociatedScene());
    }

    public void HidePopup()
    {
        PopupPanel.SetActive(false);
    }

}
