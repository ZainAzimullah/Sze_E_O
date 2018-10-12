using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Look after the player's progress through the level, control game flow
public class LevelLogicManager : Singleton<LevelLogicManager> {
    // Store minigame information
    private AbstractMinigameRecorder minigameRecorder;
    private AbstractInteractionController interactionController;
    public readonly int LEVEL_THRESHHOLD = 100;  // points needed to progress

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
        interactionController = InteractionControllerFactory.GetInteractionController(LevelManager.Instance.currentLevel);

    }

    public void MinigameDone(SceneEnum minigame)
    {
        minigameRecorder.RegisterMinigameComplete(minigame);

        if (minigameRecorder.CanShowDialogueWithColleague())
        {
            SceneTransitionManager.Instance.LoadScene(SceneEnum.GregDialogueAfterMinigame);
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
        interactionController.Interact(collision);
    }
}
