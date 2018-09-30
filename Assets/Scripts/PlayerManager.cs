public class PlayerManager {

    private static PlayerManager _this_;
    public BadgeType badge;
    public int experience;
	public int money;

    private PlayerManager() { }

    public static PlayerManager instance() {
        if (_this_ == null) {
            _this_ = new PlayerManager();
        }

        return _this_;
    }

	public int getExperience() {
		return experience;
	}

	public void updateExperience(int gainedExperience) {
		experience += gainedExperience;
	}

	public int getMoney() {
		return money;
	}

	public void updateMoney(int moneyEarned) {
		money += moneyEarned;
	}

}

public enum BadgeType {
    GRADUATE,
    TEAM_LEAD,
    CEO
}
