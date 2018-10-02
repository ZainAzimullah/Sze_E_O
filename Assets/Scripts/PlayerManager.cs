using UnityEngine;

public class PlayerManager:Singleton<PlayerManager> {
    public BadgeType badge;
    //the direction where the player face at
    public Vector3 faceTo
    {
        get; set;
    }
    //the position where the player is
    public Vector3 playerPosition
    {
        get; set;
    }
    //the main camera angle
    public Vector3 camAngle
    {
        get;set;
    }
    //the position of the main camera
    public Vector3 camPos
    {
        get;set;
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
