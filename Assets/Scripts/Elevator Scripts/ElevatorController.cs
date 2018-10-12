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
        Debug.Log(badgeType);
        Debug.Log(PlayerManager.Instance.badge);
        if (PlayerManager.Instance.GetExperience().CurrentVal == LevelLogicManager.Instance.LEVEL_THRESHHOLD 
            || PlayerManager.Instance.badge >= badgeType)
        {
            LevelManager.Instance.currentLevel = (int) badgeType;
            if (PlayerManager.Instance.badge < badgeType)
            {
                PlayerManager.Instance.badge = badgeType;
                PlayerManager.Instance.Refresh();
                LevelLogicManager.Instance.PrepareForFirstVisit();
            }
            else
            {
                LevelLogicManager.Instance.PrepareForRevisit();
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
