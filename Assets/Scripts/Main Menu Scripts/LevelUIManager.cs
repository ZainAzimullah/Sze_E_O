using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : Singleton<LevelUIManager> {
    public GameObject dialogPanel;

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
	}

    public void OnResumeButtonClicked()
    {
        dialogPanel.SetActive(false);
        Time.timeScale = 1;
        isCamFreeze = false;
    }


}
