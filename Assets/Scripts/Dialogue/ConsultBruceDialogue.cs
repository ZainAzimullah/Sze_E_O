using System.Collections;
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
            sentences = new string[] { "Bruce: Hi Sze, congratulations on completing this level, you can move on and be the Manager now." };
        }
        // Determine what Bruce should say upon approaching him after:
        //  - player can go to next level since all minigames are played
        //  - player got the dialogue answer wrong
        else if (GameLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithMentor())
        {
            sentences = new string[] { "Bruce: Hi Sze, you can go to the next level now." };
        }

        // Start typing
        StartCoroutine(Type());
    }
}