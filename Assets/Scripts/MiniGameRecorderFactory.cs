using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// Factory pattern used here
public class MinigameRecorderFactory
{
    private static AbstractMinigameRecorder minigameRecorder;

    public static AbstractMinigameRecorder GetMiniGameRecorderForLevel(int level)
    {
        switch (level)
        {
            case 1:
                return new Level1MinigameRecorder();
            case 2:
                return new Level2MinigameRecorder();
            default:
                Debug.Log(level);
                throw new NoMiniGameForThisLevelException();
        }
    }
}