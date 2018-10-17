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
    private IDictionary<int, bool> hackedLevels = new Dictionary<int, bool>()
    {
        {1, false},
        {2, false},
        {3, false}
    };

    // points needed to progress
    public readonly int LEVEL_THRESHOLD = 100;

    // remember if we need to show a popup or if a request to show the popup has been made
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

    // Press 'H' key.  Used for testing/marking
    internal void Hack()
    {
        // Only let hack work if we're not in the foyer and the next level hasn't already been hacked.
        if (LevelManager.Instance.currentLevel != 0 && !hackedLevels[LevelManager.Instance.currentLevel])
        {
            // Update experience and badge, increment max level
            PlayerManager.Instance.UpdateExperience(100);
            PlayerManager.Instance.badge = (BadgeType)(PlayerManager.Instance.badge + 1);
            LevelManager.Instance.IncreaseMaxLevel();

            // Send signal to show popup
            GameLogicManager.Instance.readyToShowBadgePopUp = true;

            // Record that the level has been hacked
            hackedLevels[LevelManager.Instance.currentLevel] = true;
        }
    }

    // This is called when a minigame has been completed
    // Using the Strategy Pattern, the minigameRecorder can determine
    // what to do for different levels when certain minigames are complete.
    public void MinigameDone(SceneName minigame)
    {
        minigameRecorder.RegisterMinigameComplete(minigame);

        // If they are playing the minigame unncessarily (they have access to higher levels)
        // then don't do anything
        if (LevelManager.Instance.GetMaxLevel() != LevelManager.Instance.currentLevel)
        {
            SceneTransitionManager.Instance.LoadCurrentLevelScene();
            return;
        }

        // If they have played enough minigames for dialogue, then show the confrontation
        if (minigameRecorder.CanShowDialogueWithColleague())
        {
            levelController.ColleagueConfrontation();
        }
        else if (minigameRecorder.CanShowDialogueWithMentor())
        {
            // They failed the confrontational dialogue earlier, so show the mentor
            SceneTransitionManager.Instance.LoadScene(SceneName.MentorAdviceDialogue);
        } else
        {
            // They haven't done enough minigames, return to the level
            SceneTransitionManager.Instance.LoadCurrentLevelScene();

        }
    }

    // Forget which levels we hacked
    internal void ResetHack()
    {
        for (int i = 1; i <= hackedLevels.Count; i++)
        {
            hackedLevels[i] = false;
        }
    }

    // Call this when dialogue has been finished and we will decide what t do next
    public void DialogueDone()
    {
        SceneTransitionManager.Instance.LoadCurrentLevelScene();

        // Show the badge popup if we have been asked to
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
