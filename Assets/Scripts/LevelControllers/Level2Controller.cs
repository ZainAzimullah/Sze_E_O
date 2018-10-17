using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : AbstractLevelController
{
    // Tags for items that can be interacted with go here
    private enum Level2Tag
    {
        Bruce,
        L2Computer,
        L2Computer1,
        L2Computer2,
        L2Computer3,
        L2Computer4,
        L2Computer5,
        L2Computer6,
        L2Computer7
    }

    private readonly IDictionary<Level2Tag, SceneName> tagToScene = new Dictionary<Level2Tag, SceneName>()
    {
        // The appropraite scene to load when interacting with that item goes here
        {Level2Tag.Bruce, SceneName.ConsultBruceDialogue},
        {Level2Tag.L2Computer, SceneName.DiffGame1},
        {Level2Tag.L2Computer1, SceneName.NoBugsComputerScene},
        {Level2Tag.L2Computer2, SceneName.DiffGame2},
        {Level2Tag.L2Computer3, SceneName.NoBugsComputerScene},
        {Level2Tag.L2Computer4, SceneName.DiffGame3},
        {Level2Tag.L2Computer5, SceneName.NoBugsComputerScene},
        {Level2Tag.L2Computer6, SceneName.NoBugsComputerScene},
        {Level2Tag.L2Computer7, SceneName.DiffGame4}
    };

    public override void ColleagueConfrontation()
    {
        SceneTransitionManager.Instance.LoadScene(SceneName.BruceDialogueAfterMinigame);
    }

    protected override void InteractHook(Collider collision)
    {
        Level2Tag tag = (Level2Tag)Enum.Parse(typeof(Level2Tag), collision.gameObject.tag);

        // Load scene based on collision tag
        switch (tag)
        {
            case Level2Tag.Bruce:
                SceneTransitionManager.Instance.LoadScene(SceneName.ConsultBruceDialogue);
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