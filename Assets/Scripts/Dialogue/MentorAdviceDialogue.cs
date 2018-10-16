using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorAdviceDialogue : SimpleDialogue {

	// Use this for initialization
	public override void Start () {
        // Clear text and start typing
        ClearText();
        sentences = new string[] { MentorManager.Instance.advice };
        GameLogicManager.Instance.badgePopUpRequest = true;
        StartCoroutine(Type());
    }
}
