using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Level3MinigameRecorder : AbstractMinigameRecorder
{
    public Level3MinigameRecorder()
    {
        Initialise();
    }

    protected override void Initialise()
    {
        allMinigames = new HashSet<SceneName>()
        {
            SceneName.ShortestPathGame1,
            SceneName.ShortestPathGame2,
            SceneName.ShortestPathGame3,
            SceneName.ShortestPathGame4
        };
        requiredMinigamesForDialogue = 3;
    }
}