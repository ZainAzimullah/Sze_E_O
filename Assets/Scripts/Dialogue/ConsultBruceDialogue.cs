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
        if (GameLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithColleague() && PlayerManager.Instance.GetExperience().CurrentVal == GameLogicManager.Instance.LEVEL_THRESHOLD)
        {
            /* Uncomment the line of code and put in what he should say:*/
            //sentences = new string[] { "Bruce: " };
            throw new System.NotImplementedException();
        }
        // Determine what Greg should say upon approaching him after failing confrontation earlier
        else if (GameLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithMentor())
        {
            /* Uncomment the line of code and put in what he should say:*/
            //sentences = new string[] { "Bruce: " };
            throw new System.NotImplementedException();
        }

        // Start typing
        StartCoroutine(Type());
    }
}