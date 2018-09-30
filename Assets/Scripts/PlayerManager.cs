
using UnityEngine;

public class PlayerManager:Singleton<PlayerManager> {
    public GameObject gb;
    public BadgeType badge;
    public int experience;
    
    public Vector3 faceTo
    {
        get;set;
    }
    
    public Vector3 playerPosition
    {
        get;set;

    }
    public void UpdateExperience(int experience1)
    {
        experience += experience1;
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(gb);
    }

}

public enum BadgeType
{
    GRADUATE,
    TEAM_LEAD,
    CEO
}
