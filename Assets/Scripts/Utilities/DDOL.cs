using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour {

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneTransitionManager.Instance.LoadScene(SceneName.MainMenu);
    }
}
