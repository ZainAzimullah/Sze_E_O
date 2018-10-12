using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager> {

    //a property to indicate what the previous scene
    public SceneEnum previousScene
    {
        get; set;
    }
    //a property to indicate what the current scene
    public SceneEnum currentScene
    {
        get; set;
    }


    private void Awake()
    {
        
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
    public void LoadScene(SceneEnum currentScene)
    {
        //Debug.Log(PlayerManager.Instance.camPos);
        previousScene = this.currentScene;
        this.currentScene = currentScene;
        string scene = MapScene(currentScene);
        SceneManager.LoadScene(scene);
    }

    public void LoadCurrentLevelScene()
    {
        LoadScene((SceneEnum) LevelManager.Instance.currentLevel);
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
    private string MapScene(SceneEnum scene)
    {
        string sceneName = Enum.GetName(typeof(SceneEnum), scene);
        return sceneName;
    }
}


/**
 * A group of enums to represent the name of the scene
 */
public enum SceneEnum
{
    // LEVELS GO HERE //

    // *** DO NOT CHANGE THIS ORDER *** //
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

public static class BadgeTypeExtension
{
    public static SceneEnum GetAssociatedScene(this BadgeType badgeType)
    {
        switch (badgeType)
        {
            case BadgeType.NEW_PLAYER:
                return SceneEnum.Level0;
            case BadgeType.GRADUATE:
                return SceneEnum.Level1;
            case BadgeType.TEAM_LEAD:
                return SceneEnum.Level2;
            case BadgeType.MANAGER:
                return SceneEnum.Level3;
            case BadgeType.CEO:
                return SceneEnum.ExitScreen;
        }

        throw new BadgeToSceneMappingException();
    }
}
