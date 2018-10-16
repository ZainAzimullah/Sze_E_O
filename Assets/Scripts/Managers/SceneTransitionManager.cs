using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager> {

    public SceneName previousScene
    {
        get; set;
    }

    public SceneName currentScene
    {
        get; set;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    /**
     * A method to load the scene;
     * @param currentScene A enum to inidicate which scene is to be loaded
     */
    public void LoadScene(SceneName currentScene)
    {
        previousScene = this.currentScene;
        this.currentScene = currentScene;
        string scene = MapScene(currentScene);
        SceneManager.LoadScene(scene);
    }

    // Go back to showing the current level.
    // Normally this is used for exiting a dialogue.
    public void LoadCurrentLevelScene()
    {
        LoadScene((SceneName) LevelManager.Instance.currentLevel);
    }

    /**
     *A method to load the previous scene
     */
    public void LoadPreviousScene()
    {
        string scene = MapScene(previousScene);
        SceneManager.LoadScene(scene);
    }

    /**
     * A helper method to map between Enum and String
     */
    private string MapScene(SceneName scene)
    {
        string sceneName = Enum.GetName(typeof(SceneName), scene);
        return sceneName;
    }
}


/**
 * A group of enums to represent the name of the scene
 */
public enum SceneName
{
    // LEVELS GO HERE //
    // *** THESE NEED TO BE IN ORDER *** //
    Level0,
    Level1,
    Level2,
    Level3,
    // ****** //

    // OTHER SCENES //
    MainMenu,
    Options,
    Elevator,
    ConsultGregDialog,
    GregDialogueAfterMinigame,
    BooleanGame,
    BooleanGame2,
    BooleanGame3,
    BooleanGame4,
    MentorAdviceDialogue,
    ExitScreen,
    NoBugsComputerScene,
    IntroAtComputerDialog,
    IntroDialogue
}

// Extension methods for the BadgeType enum
public static class BadgeTypeExtension
{
    // Get the SceneName that corresponds to the badge
    public static SceneName GetAssociatedScene(this BadgeType badgeType)
    {
        switch (badgeType)
        {
            case BadgeType.NewPlayer:
                return SceneName.Level0;
            case BadgeType.Graduate:
                return SceneName.Level1;
            case BadgeType.TeamLeader:
                return SceneName.Level2;
            case BadgeType.Manager:
                return SceneName.Level3;
            case BadgeType.CEO:
                return SceneName.ExitScreen;
        }

        throw new BadgeToSceneMappingException();
    }
}
