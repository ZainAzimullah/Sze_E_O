using System.Collections.Generic;

internal class Level2MinigameRecorder : AbstractMinigameRecorder
{
    public Level2MinigameRecorder()
    {
        Initialise();
    }

    protected override void Initialise()
    {
        allMinigames = new HashSet<SceneName>()
        {
            SceneName.DiffGame1,
            SceneName.DiffGame2,
            SceneName.DiffGame3,
            SceneName.DiffGame4
        };
        requiredMinigamesForDialogue = 3;
    }
}