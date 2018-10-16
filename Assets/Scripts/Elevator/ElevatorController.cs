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
        CheckVisit(BadgeType.TeamLeader);
    }

    public void LevelThree()
    {
        CheckVisit(BadgeType.MANAGER);
    }

    public void WinGame()
    {
        CheckVisit(BadgeType.CEO);
    }

    private void CheckVisit(BadgeType requiredBadge)
    {
        if (PlayerManager.Instance.HasVisited(requiredBadge.GetAssociatedScene()))
        {
            LevelManager.Instance.currentLevel = (int)requiredBadge;
            GameLogicManager.Instance.PrepareForRevisit();
        } else if (PlayerManager.Instance.badge == BadgeType.NEW_PLAYER
            && requiredBadge == BadgeType.GRADUATE)
        {
            PlayerManager.Instance.badge = BadgeType.GRADUATE;
            LevelManager.Instance.currentLevel = (int)requiredBadge;
            PlayerManager.Instance.Refresh();
            PlayerManager.Instance.RecordVisited(requiredBadge.GetAssociatedScene());
            GameLogicManager.Instance.PrepareForFirstVisit();
        } else if (PlayerManager.Instance.badge == BadgeType.CEO)
        {
            PlayerManager.Instance.Refresh();
            
        } else if (PlayerManager.Instance.badge == requiredBadge)
        {
            LevelManager.Instance.currentLevel = (int)requiredBadge;
            PlayerManager.Instance.Refresh();
            PlayerManager.Instance.RecordVisited(requiredBadge.GetAssociatedScene());
            GameLogicManager.Instance.PrepareForFirstVisit();
        } else
        {
            PopupPanel.SetActive(true);
            return;
        }

        SceneTransitionManager.Instance.LoadScene(requiredBadge.GetAssociatedScene());
    }

    public void HidePopup()
    {
        PopupPanel.SetActive(false);
    }

}
