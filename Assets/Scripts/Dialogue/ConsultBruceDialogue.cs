using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsultBruceDialogue : SimpleDialogue
{

    // Use this for initialization
    public override void Start()
    {
        ClearText();

        // Determine what Greg should say upon approaching him
        if (LevelLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithColleague() && PlayerManager.Instance.GetExperience().CurrentVal == LevelLogicManager.Instance.LEVEL_THRESHHOLD)
        {
            /* Uncomment the line of code and put in what he should say:*/
            //sentences = new string[] { "Bruce: " };
            throw new System.NotImplementedException();
        }
        // Determine what Greg should say upon approaching him after failing confrontation earlier
        else if (LevelLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithMentor())
        {
            /* Uncomment the line of code and put in what he should say:*/
            //sentences = new string[] { "Bruce: " };
            throw new System.NotImplementedException();
        }

        // Start typing
        StartCoroutine(Type());
    }
}