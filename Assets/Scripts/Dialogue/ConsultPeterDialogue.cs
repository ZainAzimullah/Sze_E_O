public class ConsultPeterDialogue : SimpleDialogue
{
    // Use this for initialization
    public override void Start()
    {
        ClearText();

        // Determine what Peter should say upon approaching him after:
        //  - player can already go to next level
        //  - player got dialogue answer correct
        if (GameLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithColleague() && PlayerManager.Instance.GetExperience().CurrentVal == GameLogicManager.Instance.LEVEL_THRESHOLD)
        {
            sentences = new string[] { "Peter: Hey Sze!!! Go to level 4 to honor your success :D" };
        }
        // Determine what Peter should say upon approaching him after:
        //  - player can go to next level since all minigames are played
        //  - player got the dialogue answer wrong
        else if (GameLogicManager.Instance.GetMinigameRecorder().CanShowDialogueWithMentor())
        {
            sentences = new string[] { "Peter: Sze, go to level 4 :|" };
        }

        // Start typing
        StartCoroutine(Type());
    }
}