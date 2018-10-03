using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour {
 

	// Use this for initialization
	void Start () {
		
	}

	public void returnToMain() {
        Application.Quit();
	}

}
