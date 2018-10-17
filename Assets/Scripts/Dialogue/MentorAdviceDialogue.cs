using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorAdviceDialogue : SimpleDialogue {

	// Use this for initialization
	public override void Start () {
        ClearText();
        // Fetch the advice the mentor needs to give.  Advice is stored in MentoryManager
        sentences = new string[] { MentorManager.Instance.advice };

        // Notify the GameLogicManager that a badge should be awarded after this.
        GameLogicManager.Instance.badgePopUpRequest = true;

        // Start presenting the dialogue
        StartCoroutine(Type());
    }
}
