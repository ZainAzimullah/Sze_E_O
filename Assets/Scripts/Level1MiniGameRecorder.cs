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

    public bool CanShowDialogueWithColleague()
    {
        return playedMinigames.Count == REQUIRED_MINIGAMES_FOR_DIALOGUE;
    }

    public bool CanShowDialogueWithMentor()
    {
        return playedMinigames.SetEquals(allMinigames);
    }

    public void RegisterMinigameComplete(MinigameType minigame)
    {
        if (!allMinigames.Contains(minigame))
        {
            throw new MiniGameDoesNotBelongToThisLevelException();
        }
        playedMinigames.Add(minigame);
    }
}