using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal class Level1MinigameRecorder : IMinigameRecorder
{
    private const int REQUIRED_MINIGAMES_FOR_DIALOGUE = 3;

    public Level1MinigameRecorder()
    {
    }

    private HashSet<MinigameType> playedMinigames = new HashSet<MinigameType>();
    private HashSet<MinigameType> allMinigames = new HashSet<MinigameType>()
    {
        MinigameType.BooleanGame,
        MinigameType.BooleanGame2,
        MinigameType.BooleanGame3,
        MinigameType.BooleanGame4
    };

    // Check if player has done enough minigames for dialogue
    public bool CanShowDialogueWithColleague()
    {
        return playedMinigames.Count == REQUIRED_MINIGAMES_FOR_DIALOGUE;
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