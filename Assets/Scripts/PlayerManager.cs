
using UnityEngine;

public class PlayerManager:Singleton<PlayerManager> {
    public GameObject gb;
    //private static PlayerManager _this_;
    public BadgeType badge;
    public int experience;
    public Vector3 player;
    public Vector3 faceTo
    {
        get;set;
    }

    public void setPlayer(Vector3 t)
    {
        player = t;
    }

    public Vector3 getPlayer()
    {
        return player;
    }

    
    /*public Transform playerPosition
    {
        get;set;

    }*/
    public void UpdateExperience(int experience1)
    {
        experience += experience1;
    }
    //private PlayerManager() { }

    private void Awake()
    {
        DontDestroyOnLoad(gb);
    }
    /*public static PlayerManager instance()
    {
        if (_this_ == null)
        {
            _this_ = new PlayerManager();
        }

        return _this_;
    }-=*/




}

public enum BadgeType
{
    GRADUATE,
    TEAM_LEAD,
    CEO
}
