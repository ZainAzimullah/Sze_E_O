using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Look after the player's progress through the level, control game flow
public class LevelLogicManager : Singleton<LevelLogicManager> {
    // Store minigame information
    private IMinigameRecorder minigameRecorder;
    public readonly int LEVEL_THRESHHOLD = 100;  // points needed to progress

    public IMinigameRecorder GetMinigameRecorder()
    {
        return minigameRecorder;
    }

    public void PrepareLevel()
    {
        minigameRecorder = MinigameRecorderFactory.GetMiniGameRecorderForLevel(LevelManager.Instance.currentLevel);
        PlayerManager.Instance.Refresh();
    }

    public void MinigameDone(MinigameType minigame)
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
}
