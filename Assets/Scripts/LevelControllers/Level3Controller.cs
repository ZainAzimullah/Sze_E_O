using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

public class Level3Controller : AbstractLevelController
{
    private enum Level3Tag
    {
        Peter,
        L3Computer,
        L3Computer1,
        L3Computer2,
        L3Computer3,
        L3Computer4
    }

    private readonly IDictionary<Level3Tag, SceneName> tagToScene = new Dictionary<Level3Tag, SceneName>()
    {
        {Level3Tag.Peter, SceneName.ConsultPeterDialogue},
        {Level3Tag.L3Computer, SceneName.NoBugsComputerScene},
        {Level3Tag.L3Computer1, SceneName.ShortestPathGame1},
        {Level3Tag.L3Computer2, SceneName.ShortestPathGame2},
        {Level3Tag.L3Computer3, SceneName.ShortestPathGame3},
        {Level3Tag.L3Computer4, SceneName.ShortestPathGame4}
    };

    public override void ColleagueConfrontation()
    {
        SceneTransitionManager.Instance.LoadScene(SceneName.PeterDialogueAfterMinigame);
    }

    protected override void InteractHook(Collider collision)
    {
        Level3Tag tag = (Level3Tag)Enum.Parse(typeof(Level3Tag), collision.gameObject.tag);

        switch (tag)
        {
            case Level3Tag.Peter:
                SceneTransitionManager.Instance.LoadScene(SceneName.ConsultPeterDialogue);
                break;
            default:
                // They must have interacted with a computer if we end up here.
                // Check that the minigame on the computer has been done and if its not then
                // transition to it.
                if (GameLogicManager.Instance.GetMinigameRecorder().HasCompleted(tagToScene[tag]))
                {
                    SceneTransitionManager.Instance.LoadScene(SceneName.NoBugsComputerScene);
                }
                else
                {
                    SceneTransitionManager.Instance.LoadScene(tagToScene[tag]);
                }
                break;
        }
    }
}