using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : Singleton<LevelUIManager> {
    public GameObject dialogPanel;

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
            dialogPanel.SetActive(true);
            Time.timeScale = 0;
            isCamFreeze = true;
        }
	}

    public void OnResumeButtonClicked()
    {
        dialogPanel.SetActive(false);
        Time.timeScale = 1;
        isCamFreeze = false;
    }


}
