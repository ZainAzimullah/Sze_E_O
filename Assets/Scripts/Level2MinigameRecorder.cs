using System.Collections.Generic;

internal class Level2MinigameRecorder : AbstractMinigameRecorder
{
    public Level2MinigameRecorder()
    {
        Initialise();
    }

    protected override void Initialise()
    {
        allMinigames = new HashSet<SceneEnum>()
        {
            // PUT MINIGAMES HERE
        };
        requiredMinigamesForDialogue = 3;
    }
}