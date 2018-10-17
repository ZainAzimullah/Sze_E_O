using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Adapter Pattern (class inheritance style) has been used here.
 * 
 * Special subclass of SimpleDialogue used for a conversation
 * followed by questions with multiple answers the player must choose from.
 * Upon choosing an answer, the colleague reacts in a certain way (and the mentor
 * may respond accordingly later).
 */
public class Dialogue : SimpleDialogue {
    public int CORRECT_ANSWER; // The correct answer 

    // Q&A info
    public string[] colleagueReactions; // The reactions the colleague will have (depends on answer)
    public string[] mentorAdvice; // The advice the mentor could give (depends on answer)
    private int answer = -1; // The answer the user chose
    private bool answered; // Has the player answered?

    // Buttons
    public GameObject prompt; // The question
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject buttonD;

    void Update()
    {
        // Check if dialogue needs to wait for user's response to the bad comment from colleague
        if (IsTypedOut() && IsLastSentence() && !IsFinished())
        {
            BrightenMainCharacter();
            ShowReplyOptions();
        }
    }

    // BUTTON HANDLERS //
    public void ButtonA()
    {
        answer = 0;
        Resume();
    }
    public void ButtonB()
    {
        answer = 1;
        Resume();
    }
    public void ButtonC()
    {
        answer = 2;
        Resume();
    }
    public void ButtonD()
    {
        answer = 3;
        Resume();
    }

    /*
     * Carry on dialogue after player responded
     */
    private void Resume()
    {
        // Check correct
        if (answer == CORRECT_ANSWER)
        {
            PlayerManager.Instance.UpdateExperience((PlayerManager.Instance.GetExperience().MaxVal - PlayerManager.Instance.GetExperience().CurrentVal));
            GameLogicManager.Instance.badgePopUpRequest = true;
        }

        // Store information and resume conversation
        ClearText();
        HideReplyOptions();
        index = 0;
        answered = true;
        MentorManager.Instance.advice = mentorAdvice[answer];
        sentences = new string[] { colleagueReactions[answer] };
        StartCoroutine(Type());
    }

    // Show the multichoice answers the user can select
    private void ShowReplyOptions()
    {
        continueButton.SetActive(false);
        prompt.SetActive(true);
        buttonA.SetActive(true);
        buttonB.SetActive(true);
        buttonC.SetActive(true);
        buttonD.SetActive(true);
    }

    // Hide the multichoice answers so that speech can be displayed
    private void HideReplyOptions()
    {
        continueButton.SetActive(true);
        prompt.SetActive(false);
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonC.SetActive(false);
        buttonD.SetActive(false);
    }

    // Determine whether the dialogue is finished
    public override bool IsFinished()
    {
        return answered && IsLastSentence() && IsTypedOut();
    }

    // Call this when done with the dialogue
    public override void Finish()
    {
        base.Finish();
    }
}
