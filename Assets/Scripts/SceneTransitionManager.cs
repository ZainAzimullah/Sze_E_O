using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {

    private SceneTransitionManager manager;

    public SceneEnum CurrentScene
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

    public SceneTransitionManager GetInstance()
    {
        if (manager == null)
        {
            manager = new SceneTransitionManager();
        }
        return manager;
    }

    public void LoadScene()
    {
        string scene = MapScene(CurrentScene);
        SceneManager.LoadScene(scene);
    }

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
