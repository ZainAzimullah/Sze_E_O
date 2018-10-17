using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Store information about the current level
// NB:  THIS CLASS MUST BE IN THE PRELOAD SCENE
public class LevelManager : Singleton<LevelManager> {

    public int currentLevel
    {
        get; set;
    }

    private int maxLevel;

	// Use this for initialization
	void Start () {
        maxLevel = 1;
        currentLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Increase the max level when the player is advancing
    public void IncreaseMaxLevel()
    {
        maxLevel++;
        PlayerManager.Instance.AddTracker();
    }

    public void DecreaseMaxLevel()
    {
        maxLevel--;
    }

    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public void Reset()
    {
        maxLevel = 1;
        currentLevel = 0;
    }
}
