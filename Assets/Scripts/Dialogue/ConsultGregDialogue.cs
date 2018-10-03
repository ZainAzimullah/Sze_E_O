using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsultGregDialogue : SimpleDialogue {

	// Use this for initialization
	public override void Start () {
        ClearText();

        // Determine what Greg should say upon approaching him
        if (LevelLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithColleague() && PlayerManager.Instance.GetExperience().CurrentVal == LevelLogicManager.Instance.LEVEL_THRESHHOLD)
        {
            sentences = new string[] {"Greg: Progress to the next level!"};
        } else if (LevelLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithMentor())
        {
            sentences = new string[] { "Greg: There are no more bugs" };
        }

        // Start typing
        StartCoroutine(Type());
    }
}
