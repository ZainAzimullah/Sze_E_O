using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorManager {
    private static MentorManager instance;

    public string advice
    {
        get; set;
    }

    private MentorManager() { }

    public static MentorManager Instance()
    {
        if (instance == null)
        {
            instance = new MentorManager();
        }

        return instance;
    }
}
