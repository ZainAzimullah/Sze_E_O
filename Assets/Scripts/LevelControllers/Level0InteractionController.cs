using System;
using UnityEngine;

public class Level0Controller : AbstractLevelController
{
    private enum Level0Tag
    {
        TutorialComputer,
        Mentor
    }

    protected override void InteractHook(Collider collision)
    {
        Level0Tag tag = (Level0Tag) Enum.Parse(typeof(Level0Tag), collision.gameObject.tag);

        switch (tag)
        {
            case Level0Tag.TutorialComputer:
                SceneTransitionManager.Instance.LoadScene(SceneEnum.IntroAtComputerDialog);
                break;
            case Level0Tag.Mentor:
                SceneTransitionManager.Instance.LoadScene(SceneEnum.IntroDialogue);
                break;
        }
    }

    public override void ColleagueConfrontation()
    {
        throw new ColleageConfrontationOnFoyerException();
    }
}