using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1Controller : AbstractLevelController
{
    // Tags for items that can be interacted with go here
    private enum Level1Tag
    {
        Dialog,
        Computer,
        Computer1,
        Computer2,
        Computer3,
        Computer4,
        Computer5,
        Computer6,
        Computer7
    }

    private readonly IDictionary<Level1Tag, SceneName> tagToScene = new Dictionary<Level1Tag, SceneName>()
    {
        // The appropraite scene to load when interacting with that item goes here
        {Level1Tag.Computer, SceneName.BooleanGame},
        {Level1Tag.Computer1, SceneName.NoBugsComputerScene},
        {Level1Tag.Computer2, SceneName.NoBugsComputerScene},
        {Level1Tag.Computer3, SceneName.BooleanGame2},
        {Level1Tag.Computer4, SceneName.NoBugsComputerScene},
        {Level1Tag.Computer5, SceneName.BooleanGame3},
        {Level1Tag.Computer6, SceneName.BooleanGame4},
        {Level1Tag.Computer7, SceneName.NoBugsComputerScene},

    };

    protected override void InteractHook(Collider collision)
    {
        Level1Tag tag = (Level1Tag)Enum.Parse(typeof(Level1Tag), collision.gameObject.tag);

        // Load scene based on collision tag
        switch (tag)
        {
            case Level1Tag.Dialog:
                SceneTransitionManager.Instance.LoadScene(SceneName.ConsultGregDialog);
                break;
            default:
                // They must have interacted with a computer if we end up here.
                // Check that the minigame on the computer has been done and if its not then
                // transition to it.
                if (GameLogicManager.Instance.GetMinigameRecorder().HasCompleted(tagToScene[tag]))
                {
                    SceneTransitionManager.Instance.LoadScene(SceneName.NoBugsComputerScene);
                } else {
                    SceneTransitionManager.Instance.LoadScene(tagToScene[tag]);
                }
                break;
        }
    }

    public override void ColleagueConfrontation()
    {
        SceneTransitionManager.Instance.LoadScene(SceneName.GregDialogueAfterMinigame);
    }
}
