using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour {
    public GameObject dialogPanel;

	// Use this for initialization
	void Start () {
        dialogPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dialogPanel.SetActive(true);
        }
	}

    public void OnResumeButtonClicked()
    {
        dialogPanel.SetActive(false);
    }


}
