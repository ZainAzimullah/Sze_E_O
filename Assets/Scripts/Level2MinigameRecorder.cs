using System.Collections.Generic;

internal class Level2MinigameRecorder : AbstractMinigameRecorder
{
    public Level2MinigameRecorder()
    {
        Initialise();
    }

    protected override void Initialise()
    {
        allMinigames = new HashSet<MinigameType>()
        {
            MinigameType.PUT_YOUR_MINI_GAMES_HERE
        };
        requiredMinigamesForDialogue = 3;
    }
}