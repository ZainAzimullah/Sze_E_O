using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void GroundButton() {
		Debug.Log("START BUTTON IS WORKING");
		SceneManager.LoadScene("Gameplay");
	}

    public void LevelOne()
    {
        Debug.Log("LEVEL ONE BUTTON IS WORKING");
        SceneManager.LoadScene("Level1");
    }

}
