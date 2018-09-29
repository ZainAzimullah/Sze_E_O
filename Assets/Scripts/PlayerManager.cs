public class PlayerManager {

    private static PlayerManager _this_;
    public BadgeType badge;
    public int experience;

    private PlayerManager() { }

    public static PlayerManager instance()
    {
        if (_this_ == null)
        {
            _this_ = new PlayerManager();
        }

        return _this_;
    }


}

public enum BadgeType
{
    GRADUATE,
    TEAM_LEAD,
    CEO
}
