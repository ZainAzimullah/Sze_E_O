using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// Factory pattern used here
public class MinigameRecorderFactory
{
    private static IMinigameRecorder minigameRecorder;

    public static IMinigameRecorder GetMiniGameRecorderForLevel(int level)
    {
        switch (level)
        {
            case 1:
                return new Level1MinigameRecorder();
            default:
                Debug.Log(level);
                throw new NoMiniGameForThisLevelException();
        }
    }
}