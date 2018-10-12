using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Look after the player's progress through the level, control game flow
public class GameLogicManager : Singleton<GameLogicManager> {
    // Store minigame information
    private AbstractMinigameRecorder minigameRecorder;
    private AbstractLevelController levelController;
    public readonly int LEVEL_THRESHOLD = 100;  // points needed to progress

    public AbstractMinigameRecorder GetMinigameRecorder()
    {
        return minigameRecorder;
    }

    public void PrepareForFirstVisit()
    {
        if (LevelManager.Instance.currentLevel != 0)
        {
            minigameRecorder = MinigameRecorderFactory.GetMiniGameRecorderForLevel(LevelManager.Instance.currentLevel);
        }
        PrepareForRevisit();
    }

    public void PrepareForRevisit()
    {
        Debug.Log("hello");
        levelController = LevelControllerFactory.GetInteractionController(LevelManager.Instance.currentLevel);
    }

    public void MinigameDone(SceneEnum minigame)
    {
        minigameRecorder.RegisterMinigameComplete(minigame);

        if (minigameRecorder.CanShowDialogueWithColleague())
        {
            levelController.ColleagueConfrontation();
        }
        else if (minigameRecorder.CanShowDialogueWithMentor())
        {
            SceneTransitionManager.Instance.LoadScene(SceneEnum.MentorAdviceDialogue);
        } else
        {
            SceneTransitionManager.Instance.LoadCurrentLevelScene();
        }
    }

    public void Interaction(Collider collision)
    {
        levelController.Interact(collision);
    }
}
