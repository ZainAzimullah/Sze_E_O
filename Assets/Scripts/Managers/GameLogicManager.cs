using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This manager manages game flow
// NB:  THIS CLASS MUST BE IN THE PRELOAD SCENE
public class GameLogicManager : Singleton<GameLogicManager> {
    // Track minigame progress
    private AbstractMinigameRecorder minigameRecorder;

    // The controller for the current level
    private AbstractLevelController levelController;

    // Remember which levels were hacked so that we don't hack them again
    private readonly IDictionary<int, bool> hackedLevels = new Dictionary<int, bool>()
    {
        {1, false},
        {2, false},
        {3, false}
    };

    // points needed to progress
    public readonly int LEVEL_THRESHOLD = 100;

    public bool badgePopUpRequest { get; set; }
    public bool readyToShowBadgePopUp { get; set; }

    public AbstractMinigameRecorder GetMinigameRecorder()
    {
        return minigameRecorder;
    }

    // Set ourselves up for a level being visited for the first time
    public void PrepareForFirstVisit()
    {
        if (LevelManager.Instance.currentLevel != 0)
        {
            minigameRecorder = MinigameRecorderFactory.GetMiniGameRecorderForLevel(LevelManager.Instance.currentLevel);
        }
        PrepareForRevisit();
    }

    // Set ourselves up for a level being visited
    // Since we have been to this level before, we don't want to lose track
    // of everything and only some things need to be prepared
    public void PrepareForRevisit()
    {
        levelController = LevelControllerFactory.GetInteractionController(LevelManager.Instance.currentLevel);
    }

    internal void Hack()
    {
        if (LevelManager.Instance.currentLevel != 0 && !hackedLevels[LevelManager.Instance.currentLevel])
        {
            PlayerManager.Instance.UpdateExperience(100);
            PlayerManager.Instance.badge = (BadgeType)(PlayerManager.Instance.badge + 1);
            LevelManager.Instance.IncreaseMaxLevel();
            GameLogicManager.Instance.readyToShowBadgePopUp = true;
            hackedLevels[LevelManager.Instance.currentLevel] = true;
        }
    }

    // This is called when a minigame has been completed
    // Using the Strategy Pattern, the minigameRecorder can determine
    // what to do for different levels when certain minigames are complete.
    public void MinigameDone(SceneName minigame)
    {
        minigameRecorder.RegisterMinigameComplete(minigame);

        if (LevelManager.Instance.GetMaxLevel() != LevelManager.Instance.currentLevel)
        {
            SceneTransitionManager.Instance.LoadCurrentLevelScene();
            return;
        }

        if (minigameRecorder.CanShowDialogueWithColleague())
        {
            levelController.ColleagueConfrontation();
        }
        else if (minigameRecorder.CanShowDialogueWithMentor())
        {
            SceneTransitionManager.Instance.LoadScene(SceneName.MentorAdviceDialogue);
        } else
        {
            SceneTransitionManager.Instance.LoadCurrentLevelScene();
        }
    }

    public void DialogueDone()
    {
        SceneTransitionManager.Instance.LoadCurrentLevelScene();
        if (badgePopUpRequest)
        {
            badgePopUpRequest = false;
            readyToShowBadgePopUp = true;
            PlayerManager.Instance.badge = (BadgeType) (PlayerManager.Instance.badge + 1);
            LevelManager.Instance.IncreaseMaxLevel();
        }
    }

    // Using the Strategy Pattern, the levelController can determine
    // what to do for different levels when certain items are interacted with.
    public void Interaction(Collider collision)
    {
        levelController.Interact(collision);
    }
}
