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
        string sceneName="";
        if (scene == SceneEnum.MAIN_MENU)
        {
            sceneName = "MainMenu";
        }
        if (scene == SceneEnum.OPTIONS)
        {
            sceneName = "Options";
        }
        if (scene == SceneEnum.LEVEL0)
        {
            sceneName = "Level0";
        }
        if (scene == SceneEnum.LEVEL1)
        {
            sceneName = "Level1";
        }
        if (scene == SceneEnum.ELEVATOR)
        {
            sceneName = "Elevator";
        }
        if (scene == SceneEnum.GREG_DIALOGUE_AFTER_MINIGAME)
        {
            sceneName = "GregDialogueAfterMinigame";
        }
        if (scene == SceneEnum.CONSULT_GREG_DIALOGUE)
        {
            sceneName = "ConsultGregDialog";
        }
        if (scene == SceneEnum.BOOLEAN_GAME)
        {
            sceneName = "BooleanGame";
        }
        return sceneName;
    }
}


/**
 * A group of enums to represent the name of the scene
 */
public enum SceneEnum
{
    MAIN_MENU,
    LEVEL0,
    LEVEL1,
    OPTIONS,
    ELEVATOR,
    CONSULT_GREG_DIALOGUE,
    GREG_DIALOGUE_AFTER_MINIGAME,
    BOOLEAN_GAME
}
