internal interface IMinigame
{
    // All minigames must decide what to do once the user is finished the minigame.
    // This method is called once a minigame is finished.  It is most likely that 
    // this method will have the responsibility of linking back to the current level.
    void Progress();
}