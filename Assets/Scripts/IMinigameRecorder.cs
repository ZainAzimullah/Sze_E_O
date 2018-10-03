public interface IMinigameRecorder
{
    bool CanShowDialogueWithColleague();
    bool CanShowDialogueWithMentor();
    void RegisterMinigameComplete(MinigameType minigame);
    bool HasCompleted(MinigameType minigameType);
}


public enum MinigameType
{
    BooleanGame,
    BooleanGame2,
    BooleanGame3,
    BooleanGame4
}