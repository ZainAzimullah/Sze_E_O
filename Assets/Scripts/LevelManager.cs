using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> {

    public int currentLevel
    {
        get;set;
    }

    private int maxLevel;

	// Use this for initialization
	void Start () {
        maxLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseMaxLevel()
    {
        maxLevel++;
    }

    public void DecreaseMaxLevel()
    {
        maxLevel--;
    }

    public int GetMaxLevel()
    {
        return maxLevel;
    }
    
}
