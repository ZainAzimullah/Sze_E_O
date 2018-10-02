using UnityEngine;

public class PlayerManager:Singleton<PlayerManager> {
    public BadgeType badge;
    
    public Vector3 faceTo
    {
        get; set;
    }

    public int money;

    [SerializeField]
    private Stat exp;

    private void Awake()
    {
        exp = new Stat();
        exp.Initialize();
        exp.MaxVal = 100;
    }

    private void Update()
    {

    }

    public Vector3 playerPosition
    {
        get;set;
    }

    public Stat GetExperience() {
        // change to return actual exp not percentage 
//        Debug.Log(exp.CurrentVal + "Current value");
        return exp;
    }

	public void UpdateExperience(float gainedExperience) {
        exp.CurrentVal += gainedExperience;
//	    Debug.Log(exp.CurrentVal + "Updated expreience");
	}

	public int GetMoney() {
		return money;
	}

	public void UpdateMoney(int moneyEarned) {
		money += moneyEarned;
	}

}

public enum BadgeType {
    GRADUATE,
    TEAM_LEAD,
    CEO
}
