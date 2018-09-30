using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleDialogue : MonoBehaviour {
    // Text
    public TextMeshProUGUI textDisplay;
    public float typingSpeed;

    // Data
    public string[] sentences;
    protected int index;
    protected bool skip = false;

    // Shaders
    public GameObject szeShader;
    public GameObject otherShader;

    // Buttons
    public GameObject continueButton;

    public virtual void Start()
    {
        // Clear text and start typing
        ClearText();
        StartCoroutine(Type());
    }

    public IEnumerator Type()
    {
        if (sentences[index].Contains("Sze"))
        {
            BrightenMainCharacter();
        }
        else
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
    }

    public void NextSentence()
    {
        if (IsFinished())
        {
            Finish();
        }
        else
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

    public virtual bool IsFinished()
    {
        return IsLastSentence() && IsTypedOut();
    }

    public virtual void Finish()
    {
        // THIS IS CALLED WHEN THE DIALOGUE IS FINISHED
    }

    public void BrightenMainCharacter()
    {
        szeShader.SetActive(false);
        otherShader.SetActive(true);
    }

    public void BrightenOtherCharacter()
    {
        szeShader.SetActive(true);
        otherShader.SetActive(false);
    }

    public bool IsTypedOut()
    {
        return textDisplay.text == sentences[index];
    }

    public bool IsLastSentence()
    {
        return index == sentences.Length - 1;
    }

    public void ClearText()
    {
        textDisplay.text = "";
    }
}