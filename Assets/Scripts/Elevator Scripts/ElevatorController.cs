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
        if (PlayerManager.Instance.GetExperience().CurrentVal == GameLogicManager.Instance.LEVEL_THRESHOLD 
            || PlayerManager.Instance.badge >= badgeType)
        {
            LevelManager.Instance.currentLevel = (int) badgeType;
            if (PlayerManager.Instance.badge < badgeType)
            {
                PlayerManager.Instance.badge = badgeType;
                PlayerManager.Instance.Refresh();
                GameLogicManager.Instance.PrepareForFirstVisit();
            }
            else
            {
                GameLogicManager.Instance.PrepareForRevisit();
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
