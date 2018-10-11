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
    MainMenu,
    Level0,
    Level1,
    Level2,
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
