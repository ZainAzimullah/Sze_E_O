using System.Collections.Generic;
using UnityEngine;

public class PlayerManager:Singleton<PlayerManager> {
    public BadgeType badge;
    private List<Tracker> trackers; 
    public int money;

    [SerializeField]
    private Stat exp; // Experience points the player has

    private void Awake()
    {
        // Initialise experience info
        exp = new Stat();
        exp.Initialize();
        exp.MaxVal = 100;
        InitializeTracker();
    }

    void Update()
    {
        // Exit on Esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public Stat GetExperience() {
        return exp;
    }

	public void UpdateExperience(float gainedExperience) {
        exp.CurrentVal += gainedExperience;
	}

	public int GetMoney() {
		return money;
	}

	public void UpdateMoney(int moneyEarned) {
		money += moneyEarned;
	}

    public List<Tracker> GetTrackers()
    {
        return trackers;
    }

    public Tracker GetTracker(int index)
    {
        
        return trackers[index];
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

}

public enum BadgeType {
    GRADUATE,
    TEAM_LEAD,
    CEO
}
