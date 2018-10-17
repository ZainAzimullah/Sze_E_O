using System;
using System.Collections.Generic;
using UnityEngine;

// All important data regarding the player is stored here throughout
// the duration of the game.
// NB:  THIS CLASS MUST BE IN THE PRELOAD SCENE
public class PlayerManager:Singleton<PlayerManager> {
    public BadgeType badge = BadgeType.NewPlayer; // The current badge used for level access
    private List<Tracker> trackers; // Tracking the position of the player
    public int money; // Money the player has collected

    [SerializeField]
    private Stat exp; // Experience points the player has
    private HashSet<SceneName> visitedLevels;

    public PlayerMode mode
    {
        get; set;
    }

    private void Awake()
    {
        // Initialise experience info
        exp = new Stat();
        exp.Initialize();
        exp.MaxVal = 100;
        InitializeTracker();

        visitedLevels = new HashSet<SceneName>();
        visitedLevels.Add(SceneName.Level0);
    }

    public void RecordVisited(SceneName level)
    {
        visitedLevels.Add(level);
    }

    public bool HasVisited(SceneName level)
    {
        return visitedLevels.Contains(level);
    }

    public void AddTracker()
    {
        trackers.Add(new Tracker());
    }

    void Update()
    {
        // Exit on Esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Hack for testing (press Enter)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameLogicManager.Instance.Hack();
        }
    }


    public Stat GetExperience() {
        return exp;
    }

	public void UpdateExperience(float gainedExperience) {
        exp.CurrentVal += gainedExperience;
        if (exp.CurrentVal > 100)
        {
            exp.CurrentVal = 100;
        }
	}

	public int GetMoney() {
		return money;
	}

	public void UpdateMoney(int moneyEarned) {
		money += moneyEarned;
        Debug.Log(money);
	}

    public List<Tracker> GetTrackers()
    {
        return trackers;
    }

    public Tracker GetTracker(int index)
    {
        
        return trackers[index];
    }

    //Get the number of levels of player and camera positions have been stored
    public int GetNumberofTrackers()
    {
        return trackers.Count;
    }

    void InitializeTracker()
    {
        // To track the player and camera in every level
        trackers = new List<Tracker>();
        for(int i = 0; i <= LevelManager.Instance.GetMaxLevel()+1; i++)
        {
            trackers.Add(new Tracker());
        }
        
    }

    //To clear all the stored player and camera positions and angles
    public void ReinitializeTracker()
    {
        trackers.Clear();
        InitializeTracker();
    }

    // Things we need to do when resetting the player for different levels
    public void Refresh()
    {
        exp.CurrentVal = 0;
    }

}

public enum PlayerMode
{
    TUTORIAL,
    NORMAL,
    TESTING
}

// THE ORDER MATTERS FOR THIS ENUM
// Place in order of job ranking
// The ordinal (index) must match the level number
public enum BadgeType {
    NewPlayer, // Level 0
    Graduate,   // Level 1
    TeamLeader,  // Level 2
    Manager,    // Level 3
    CEO         // Game Over
}
