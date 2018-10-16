using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : Singleton<LevelUIManager> {
    public GameObject dialogPanel;
    public GameObject badgePanel;

    private bool isESCPressed;

    public bool isCamFreeze
    {
        get;set;
    }

	// Use this for initialization
	void Start () {
        dialogPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isESCPressed = !isESCPressed;
            if (isESCPressed)
            {
                dialogPanel.SetActive(true);

                //Freeze camera and movement
                Time.timeScale = 0;
                isCamFreeze = true;
            }
            else
            {
                //when ESC is pressed twice, 
                //do the same behaviour 
                //as the resume button is clicked
                OnResumeButtonClicked();
            }            
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ShowBadgePanel();
        }
	}

    public void OnResumeButtonClicked()
    {
        isESCPressed = false;
        dialogPanel.SetActive(false);
        Time.timeScale = 1;
        isCamFreeze = false;
    }

    //The method you need to call when you wanna show the badge panel(The panel that appears when you achieve something)
    public void ShowBadgePanel()
    {
        StartCoroutine(BadgePanelTransition(2));
    }

    //A helper method to do the fade in and fade out transition
    private IEnumerator FadeCanvasGroup(CanvasGroup cg,float start,float end,float lerpTime=1f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        while (true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if(percentageComplete >= 1)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        print("done");
    }

    //A helper method to wait in seconds
    private IEnumerator BadgePanelTransition(float seconds)
    {
        CanvasGroup uiElement = badgePanel.GetComponent<CanvasGroup>();
        //Fade in the badgePanel
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, .5f));
        yield return new WaitForSeconds(seconds);
        //Fade out the badgePanel
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, .5f));
    }


}
