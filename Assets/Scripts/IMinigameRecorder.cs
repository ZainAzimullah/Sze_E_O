public interface IMinigameRecorder
{
    bool CanShowDialogueWithColleague();
    bool CanShowDialogueWithMentor();
    void RegisterMinigameComplete(MinigameType minigame);
}


public enum MinigameType
{
    BooleanGame,
    BooleanGame2,
    BooleanGame3,
    BooleanGame4
}