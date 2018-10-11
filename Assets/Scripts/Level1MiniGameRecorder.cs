using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal class Level1MinigameRecorder : AbstractMinigameRecorder
{

    public Level1MinigameRecorder()
    {
        Initialise();
    }

    protected override void Initialise()
    {
        allMinigames = new HashSet<MinigameType>()
        {
            MinigameType.BooleanGame,
            MinigameType.BooleanGame2,
            MinigameType.BooleanGame3,
            MinigameType.BooleanGame4
        };
        requiredMinigamesForDialogue = 3;
    }
}