using UnityEngine;

public class PlayerManager:Singleton<PlayerManager> {
    public GameObject gb;
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
        DontDestroyOnLoad(gb);
        exp = new Stat();
        exp.Initialize();
        exp.MaxVal = 100;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            exp.CurrentVal -= 5;
        }
        if (Input.GetKey(KeyCode.T))
        {
            exp.CurrentVal += 5;
        }
    }

    
    public Vector3 playerPosition
    {
        get;set;
    }
    
	public int GetExperience() {
        // change to return actual exp not percentage 
        return (int) exp.CurrentVal;
	}

	public void UpdateExperience(int gainedExperience) {
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
