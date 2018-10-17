﻿using System;
using UnityEngine;

public class Level0Controller : AbstractLevelController
{
    // Interactable items go here
    private enum Level0Tag
    {
        TutorialComputer,
        Mentor
    }

    protected override void InteractHook(Collider collision)
    {
        Level0Tag tag = (Level0Tag) Enum.Parse(typeof(Level0Tag), collision.gameObject.tag);

        // Check collision tag and load corresponding scene
        switch (tag)
        {
            case Level0Tag.TutorialComputer:
                SceneTransitionManager.Instance.LoadScene(SceneName.IntroAtComputerDialog);
                break;
            case Level0Tag.Mentor:
                SceneTransitionManager.Instance.LoadScene(SceneName.IntroDialogue);
                break;
        }
    }

    // We don't need this for this controller
    public override void ColleagueConfrontation()
    {
        throw new ColleageConfrontationOnFoyerException();
    }
}