using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {

    private static SceneTransitionManager manager;

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

    private SceneTransitionManager() {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static SceneTransitionManager  GetInstance()
    {
        if (manager == null)
        {
            manager = new SceneTransitionManager();
        }
        return manager;
    }

    /**
     * A method to load the scene;
     * @param currentScene A enum to inidicate which scene is to be loaded
     */
    public void LoadScene(SceneEnum currentScene)
    {
        string scene = MapScene(currentScene);
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
        if (scene == SceneEnum.LEVEL1)
        {
            sceneName = "Level1";
        }
        if (scene == SceneEnum.ELEVATOR)
        {
            sceneName = "Elevator";
        }
        if (scene == SceneEnum.DIALOGUE)
        {
            sceneName = "Dialogue";
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
    LEVEL1,
    OPTIONS,
    ELEVATOR,
    DIALOGUE,
    BOOLEAN_GAME
}
