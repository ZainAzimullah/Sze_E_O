// Interface for recorders for each level to store information
// about the completion of minigames.  Factory pattern used here.
using System.Collections.Generic;

public abstract class AbstractMinigameRecorder
{
    protected int requiredMinigamesForDialogue;
    protected HashSet<MinigameType> playedMinigames = new HashSet<MinigameType>();
    protected HashSet<MinigameType> allMinigames;

    protected abstract void Initialise();

    // Check if player has done enough minigames for dialogue
    public bool CanShowDialogueWithColleague()
    {
        return playedMinigames.Count == requiredMinigamesForDialogue;
    }

    // Check that all the minigames have been played
    public bool CanShowDialogueWithMentor()
    {
        return playedMinigames.SetEquals(allMinigames);
    }

    // Notify this that the minigame has been played
    public void RegisterMinigameComplete(MinigameType minigame)
    {
        if (!allMinigames.Contains(minigame))
        {
            throw new MiniGameDoesNotBelongToThisLevelException();
        }
        playedMinigames.Add(minigame);
    }

    // Has a particular minigame been done?
    public bool HasCompleted(MinigameType minigameType)
    {
        return playedMinigames.Contains(minigameType);
    }
}


public enum MinigameType
{
    // Level 1
    BooleanGame,
    BooleanGame2,
    BooleanGame3,
    BooleanGame4,
    
    // Level 2
    PUT_YOUR_MINI_GAMES_HERE
}