
using UnityEngine;

public class PlayerManager :MonoBehaviour{
    public GameObject gb;
    private static PlayerManager _this_;
    public BadgeType badge;
    public int experience;

    public Transform playerPosition
    {
        get;set;
    }

    private PlayerManager() { }

    private void Awake()
    {
        instance();
        DontDestroyOnLoad(gb);
    }
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
