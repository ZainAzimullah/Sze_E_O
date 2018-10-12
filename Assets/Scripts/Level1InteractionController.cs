using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1Controller : AbstractLevelController
{
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

    private readonly IDictionary<Level1Tag, SceneEnum> tagToScene = new Dictionary<Level1Tag, SceneEnum>()
    {
        {Level1Tag.Computer, SceneEnum.BooleanGame},
        {Level1Tag.Computer1, SceneEnum.NoBugsComputerScene},
        {Level1Tag.Computer2, SceneEnum.NoBugsComputerScene},
        {Level1Tag.Computer3, SceneEnum.BooleanGame2},
        {Level1Tag.Computer4, SceneEnum.NoBugsComputerScene},
        {Level1Tag.Computer5, SceneEnum.BooleanGame3},
        {Level1Tag.Computer6, SceneEnum.BooleanGame4},
        {Level1Tag.Computer7, SceneEnum.NoBugsComputerScene},

    };

    protected override void InteractHook(Collider collision)
    {
        Level1Tag tag = (Level1Tag)Enum.Parse(typeof(Level1Tag), collision.gameObject.tag);

        switch (tag)
        {
            case Level1Tag.Dialog:
                SceneTransitionManager.Instance.LoadScene(SceneEnum.ConsultGregDialog);
                break;
            default:
                if (GameLogicManager.Instance.GetMinigameRecorder().HasCompleted(tagToScene[tag]))
                {
                    SceneTransitionManager.Instance.LoadScene(SceneEnum.NoBugsComputerScene);
                } else {
                    SceneTransitionManager.Instance.LoadScene(tagToScene[tag]);
                }
                break;
        }
    }

    public override void ColleagueConfrontation()
    {
        SceneTransitionManager.Instance.LoadScene(SceneEnum.GregDialogueAfterMinigame);
    }
}
