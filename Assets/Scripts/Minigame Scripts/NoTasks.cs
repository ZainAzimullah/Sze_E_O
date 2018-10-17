using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is for computers with no tasks,
// allows user to return back to the gameworld
public class NoTasks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// This method returns to the gameworld based on the player's current level 
	// using the scene transition manager.
    public void GoBack()
    {
        SceneTransitionManager.Instance.LoadScene((SceneName) LevelManager.Instance.currentLevel);
    }
}
