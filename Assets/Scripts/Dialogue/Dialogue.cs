using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    private bool skip = false;
    public float typingSpeed;
    public GameObject continueButton;

    public GameObject prompt;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject buttonD;

    void Start()
    {
        textDisplay.text = "";
        StartCoroutine(Type());
    }

    void Update()
    {
        if ((textDisplay.text == sentences[index]) && (index == sentences.Length -1))
        {
            // print whqyurname
            prompt.SetActive(true);
            buttonA.SetActive(true);
            buttonB.SetActive(true);
            buttonC.SetActive(true);
            buttonD.SetActive(true);

        }
    }

    IEnumerator Type()
    {
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
            StartCoroutine(Type());
        }
    }


}
