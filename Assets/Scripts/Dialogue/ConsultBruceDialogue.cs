﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsultBruceDialogue : SimpleDialogue
{

    // Use this for initialization
    public override void Start()
    {
        ClearText();

        // Determine what Bruce should say upon approaching him after:
        //  - player can already go to next level
        //  - player got dialogue answer correct
        if (GameLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithColleague() && PlayerManager.Instance.GetExperience().CurrentVal == GameLogicManager.Instance.LEVEL_THRESHOLD)
        {
            /* Uncomment the line of code and put in what he should say:*/
            //sentences = new string[] { "Bruce: " };
            throw new System.NotImplementedException();
        }
        // Determine what Bruce should say upon approaching him after:
        //  - player can go to next level since all minigames are played
        //  - player got the dialogue answer wrong
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