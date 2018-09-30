using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {
    // Text
    public TextMeshProUGUI textDisplay;
    public float typingSpeed;

    // Data
    public string[] sentences;
    public string[] colleagueReactions;
    private int index;
    private bool answered;
    private bool skip = false;

    // Buttons
    public GameObject continueButton;
    public GameObject prompt;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject buttonD;

    // Shaders
    public GameObject szeShader;
    public GameObject otherShader;

    private int answer = -1;

    void Start()
    {
        // Clear text and start typing
        ClearText();
        StartCoroutine(Type());
    }

    void Update()
    {
        if (IsTypedOut() && IsLastSentence() && !IsFinished())
        {
            BrightenMainCharacter();
            ShowReplyOptions();
        }
    }

    IEnumerator Type()
    {
        if (sentences[index].Contains("Sze"))
        {
            BrightenMainCharacter();
        } else
        {
            BrightenOtherCharacter();
        }

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            if (!skip)
            {
                yield return new WaitForSeconds(typingSpeed);
            }
            
        }
        skip = false;

        if (!IsFinished() && IsLastSentence())
        {
            BrightenMainCharacter();
            ShowReplyOptions();
        }
    }

    public void NextSentence()
    {
        if (IsFinished())
        {
            Finish();
        } else
        {
            if (!IsTypedOut())
            {
                skip = true;
                return;
            }
            if (!IsLastSentence())
            {
                index++;
                ClearText();
                StartCoroutine(Type());
            }
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
        ClearText();
        HideReplyOptions();
        index = 0;
        answered = true;
        sentences = new string[] { colleagueReactions[answer] };
        StartCoroutine(Type());
    }

    public void Finish()
    {
        // THIS METHOD IS CALLED WHEN THE DIALOGUE IS FINISHED
    }

    private void BrightenMainCharacter()
    {
        szeShader.SetActive(false);
        otherShader.SetActive(true);
    }

    private void BrightenOtherCharacter()
    {
        szeShader.SetActive(true);
        otherShader.SetActive(false);
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

    private void ClearText()
    {
        textDisplay.text = "";
    }

    private bool IsTypedOut()
    {
        return textDisplay.text == sentences[index];
    }

    private bool IsLastSentence()
    {
        return index == sentences.Length - 1;
    }

    private bool IsFinished()
    {
        return answered && IsLastSentence() && IsTypedOut();
    }
}
