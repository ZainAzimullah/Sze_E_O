using System.Collections.Generic;
using UnityEngine;

public class PlayerManager:Singleton<PlayerManager> {
    public BadgeType badge;

    private List<Tracker> trackers; 


    public int money;

    [SerializeField]
    private Stat exp;

    private void Awake()
    {
        exp = new Stat();
        exp.Initialize();
        exp.MaxVal = 100;
        InitializeTracker();
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
    /**
     * Get the tracker in level "index" in the tracker list.
     */
    public Tracker GetTracker(int index)
    {
        
        return trackers[index];
    }

    void InitializeTracker()
    {
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
