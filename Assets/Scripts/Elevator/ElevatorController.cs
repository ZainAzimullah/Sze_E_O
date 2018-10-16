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
        if ((PlayerManager.Instance.GetExperience().CurrentVal == GameLogicManager.Instance.LEVEL_THRESHOLD) 
            || (PlayerManager.Instance.badge >= badgeType) 
            || (PlayerManager.Instance.mode == PlayerMode.TUTORIAL))
        {
            LevelManager.Instance.currentLevel = (int) badgeType;
            if (PlayerManager.Instance.badge == (BadgeType) (((int) badgeType) - 1))
            {
                PlayerManager.Instance.badge = badgeType;
                PlayerManager.Instance.Refresh();
                PlayerManager.Instance.mode = PlayerMode.NORMAL;
                GameLogicManager.Instance.PrepareForFirstVisit();
            }
            else if (PlayerManager.Instance.badge >= badgeType)
            {
                GameLogicManager.Instance.PrepareForRevisit();
            } else
            {
                PopupPanel.SetActive(true);
                return;
            }

            SceneTransitionManager.Instance.LoadScene(badgeType.GetAssociatedScene());
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
