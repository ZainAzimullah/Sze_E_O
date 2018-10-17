using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour {

    public Text money;

	// Use this for initialization
	void Start () {
        money.text = "$" + PlayerManager.Instance.money.ToString();
	}

	public void returnToMain() {
        SceneTransitionManager.Instance.LoadScene(SceneName.MainMenu);
	}

}
