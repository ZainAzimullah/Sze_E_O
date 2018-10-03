using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : SimpleDialogue {

    // Q&A info
    public string[] colleagueReactions;
    public string[] mentorAdvice;
    private int answer = -1;
    private bool answered;

    // Buttons
    public GameObject prompt;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject buttonD;

    void Update()
    {
        if (IsTypedOut() && IsLastSentence() && !IsFinished())
        {
            BrightenMainCharacter();
            ShowReplyOptions();
        }
    }

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

    private void Resume()
    {
        if (answer == 2)
        {
            PlayerManager.Instance.UpdateExperience((PlayerManager.Instance.GetExperience().MaxVal - PlayerManager.Instance.GetExperience().CurrentVal));
            
        }



        ClearText();
        HideReplyOptions();
        index = 0;
        answered = true;
        MentorManager.Instance.advice = mentorAdvice[answer];
        sentences = new string[] { colleagueReactions[answer] };
        StartCoroutine(Type());
    }

    private void ShowReplyOptions()
    {
        continueButton.SetActive(false);
        prompt.SetActive(true);
        buttonA.SetActive(true);
        buttonB.SetActive(true);
        buttonC.SetActive(true);
        buttonD.SetActive(true);
    }

    private void HideReplyOptions()
    {
        continueButton.SetActive(true);
        prompt.SetActive(false);
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonC.SetActive(false);
        buttonD.SetActive(false);
    }

    public override bool IsFinished()
    {
        return answered && IsLastSentence() && IsTypedOut();
    }

    public override void Finish()
    {
        base.Finish();
        //Debug.Log(MentorManager.Instance.advice);
    }
}
