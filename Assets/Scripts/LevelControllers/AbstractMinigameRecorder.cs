// Interface for recorders for each level to store information
// about the completion of minigames.  Factory pattern used here.
using System.Collections.Generic;

// Minigame recorders for each level should extend this class
public abstract class AbstractMinigameRecorder
{
    // The amount of minigames the level needs before the NPC confronts the main player
    protected int requiredMinigamesForDialogue;

    // A record of the minigames the player has played
    protected HashSet<SceneEnum> playedMinigames = new HashSet<SceneEnum>();

    // All the minigames the player has played in this level
    protected HashSet<SceneEnum> allMinigames;

    // It is your responsibility to make sure your subclass is initialised properly.
    // You must call this from the constructor
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
    public void RegisterMinigameComplete(SceneEnum minigame)
    {
        if (!allMinigames.Contains(minigame))
        {
            throw new MiniGameDoesNotBelongToThisLevelException();
        }
        playedMinigames.Add(minigame);
    }

    // Has a particular minigame been done?
    public bool HasCompleted(SceneEnum minigameType)
    {
        return playedMinigames.Contains(minigameType);
    }
}