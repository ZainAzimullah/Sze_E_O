using UnityEngine;

public class PlayerManager:MonoBehaviour
{

    private static PlayerManager _this_;
    public BadgeType badge;
    public int experience;
    public int money;

    [SerializeField]
    private Stat exp;

    private PlayerManager() { }

    private void Awake()
    {
        exp.Initialize();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            exp.CurrentVal -= 5;
        }
        if (Input.GetKey(KeyCode.W))
        {
            exp.CurrentVal += 5;
        }
    }

    public static PlayerManager Instance() {
        if (_this_ == null) {
            _this_ = new PlayerManager();
        }

        return _this_;
    }

	public int GetExperience() {
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
