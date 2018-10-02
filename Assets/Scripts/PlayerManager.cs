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

    public Vector3 playerPosition
    {
        get;set;
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

}

public enum BadgeType {
    GRADUATE,
    TEAM_LEAD,
    CEO
}
