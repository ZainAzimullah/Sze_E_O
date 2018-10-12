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
        allMinigames = new HashSet<SceneEnum>()
        {
            SceneEnum.BooleanGame,
            SceneEnum.BooleanGame2,
            SceneEnum.BooleanGame3,
            SceneEnum.BooleanGame4
        };
        requiredMinigamesForDialogue = 3;
    }
}