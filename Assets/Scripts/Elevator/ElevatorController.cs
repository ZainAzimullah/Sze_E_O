using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Handler for the elevator scene.
public class ElevatorController : MonoBehaviour {
    public GameObject PopupPanel;
    public Button btnG;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;


    // Use this for initialization
    void Start()
    {
        PopupPanel.SetActive(false);

        // Highlight the button of the current level we're on.
        Color newColor = new Color((2f/255f), (208f/255f), (255f/255f));
        switch (LevelManager.Instance.currentLevel)
        {
            case 0:
                ColorBlock colors0 = btnG.colors;
                colors0.normalColor = newColor;
                btnG.colors = colors0;
                break;
            case 1:
                ColorBlock colors1 = btn1.colors;
                colors1.normalColor = newColor;
                btn1.colors = colors1;
                break;
            case 2:
                ColorBlock colors2 = btn2.colors;
                colors2.normalColor = newColor;
                btn2.colors = colors2;
                break;
            case 3:
                ColorBlock colors3 = btn3.colors;
                colors3.normalColor = newColor;
                btn3.colors = colors3;
                break;
            case 4:
                ColorBlock colors4 = btn4.colors;
                colors4.normalColor = newColor;
                btn4.colors = colors4;
                break;
        }
    }

    //  BUTTON HANDLERS //
    public void GroundButton()
    {
        CheckVisit(BadgeType.NewPlayer);
    }

    public void LevelOne()
    {
        CheckVisit(BadgeType.Graduate);
    }

    public void LevelTwo()
    {
        CheckVisit(BadgeType.TeamLead);
    }

    public void LevelThree()
    {
        CheckVisit(BadgeType.Manager);
    }

    public void WinGame()
    {
        CheckVisit(BadgeType.CEO);
    }

    // Check that player is allowed to actually visit
    // the level that they requested.  If they are, then transition to that scene,
    // if not, show a popup.
    private void CheckVisit(BadgeType requiredBadge)
    {
        if (PlayerManager.Instance.HasVisited(requiredBadge.GetAssociatedScene()))
        {
            // If they've visited before then prepare the scene for a revisit.
            LevelManager.Instance.currentLevel = (int)requiredBadge;
            GameLogicManager.Instance.PrepareForRevisit();

        } else if (PlayerManager.Instance.badge == BadgeType.NewPlayer
            && requiredBadge == BadgeType.Graduate)
        {
            // If they are a new player going to level 1 from the foyer, 
            // we don't want to check for experience points.
            // We automatically promote their badge
            PlayerManager.Instance.badge = BadgeType.Graduate;

            // Set next level and refresh player
            LevelManager.Instance.currentLevel = (int)requiredBadge;
            PlayerManager.Instance.Refresh();

            // Log that we're visitng this level and prepare for first time
            PlayerManager.Instance.RecordVisited(requiredBadge.GetAssociatedScene());
            GameLogicManager.Instance.PrepareForFirstVisit();
        } else if (PlayerManager.Instance.badge == BadgeType.CEO)
        {
            // Nothing to do as they have won the game
            PlayerManager.Instance.Refresh();

        } else if (PlayerManager.Instance.badge == requiredBadge)
        {
            // They are eligible to go to this level for the first time.
            // Set the level and refresh player
            LevelManager.Instance.currentLevel = (int)requiredBadge;
            PlayerManager.Instance.Refresh();

            // Log that we're visiting this level and prepare it for the first time
            PlayerManager.Instance.RecordVisited(requiredBadge.GetAssociatedScene());
            GameLogicManager.Instance.PrepareForFirstVisit();
        } else
        {
            // Access denied
            PopupPanel.SetActive(true);
            return;
        }

        // Load the scene
        SceneTransitionManager.Instance.LoadScene(requiredBadge.GetAssociatedScene());
    }

    public void HidePopup()
    {
        PopupPanel.SetActive(false);
    }

}
