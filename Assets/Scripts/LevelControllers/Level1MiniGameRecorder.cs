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
        allMinigames = new HashSet<SceneName>()
        {
            SceneName.BooleanGame,
            SceneName.BooleanGame2,
            SceneName.BooleanGame3,
            SceneName.BooleanGame4
        };
        requiredMinigamesForDialogue = 3;
    }
}