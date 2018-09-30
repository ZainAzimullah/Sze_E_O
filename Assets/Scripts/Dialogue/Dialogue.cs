using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] colleagueReactions;
    private int index;
    private bool skip = false;
    public float typingSpeed;
    public GameObject continueButton;

    public GameObject prompt;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject buttonD;

    private int answer = 0;

    void Start()
    {
        textDisplay.text = "";
        StartCoroutine(Type(sentences));
    }

    void Update()
    {
        if ((textDisplay.text == sentences[index]) && (index == sentences.Length -1))
        {
            prompt.SetActive(true);
            buttonA.SetActive(true);
            buttonB.SetActive(true);
            buttonC.SetActive(true);
            buttonD.SetActive(true);

        }
    }

    IEnumerator Type(string[] conversation)
    {
        foreach (char letter in conversation[index].ToCharArray())
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
        if ((textDisplay.text != sentences[index]))
        {
            skip = true;
            return;
        }

        if (index < sentences.Length - 1)
        {
            index++;

            if ((index == sentences.Length - 1) && (textDisplay.text == sentences[index]))
            {
                continueButton.SetActive(false);
            }

            textDisplay.text = "";
            StartCoroutine(Type(sentences));
        }
    }

    public void ButtonA()
    {
        answer = 0;
        CarryOn();
    }
    public void ButtonB()
    {
        answer = 1;
        CarryOn();
    }
    public void ButtonC()
    {
        answer = 2;
        CarryOn();
    }
    public void ButtonD()
    {
        answer = 3;
        CarryOn();
    }

    private void CarryOn()
    {
        Debug.Log("yo");
        textDisplay.text = "";
        prompt.SetActive(false);
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonC.SetActive(false);
        buttonD.SetActive(false);
        index = 0;
        StartCoroutine(Type(new string[] { colleagueReactions[answer] }));

    }
}
