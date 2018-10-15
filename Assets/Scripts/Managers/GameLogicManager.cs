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

    // points needed to progress
    public readonly int LEVEL_THRESHOLD = 100;

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

    // This is called when a minigame has been completed
    // Using the Strategy Pattern, the minigameRecorder can determine
    // what to do for different levels when certain minigames are complete.
    public void MinigameDone(SceneName minigame)
    {
        minigameRecorder.RegisterMinigameComplete(minigame);

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

    // Using the Strategy Pattern, the levelController can determine
    // what to do for different levels when certain items are interacted with.
    public void Interaction(Collider collision)
    {
        levelController.Interact(collision);
    }
}
