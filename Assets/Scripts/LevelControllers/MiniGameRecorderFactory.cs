using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// Factory pattern used here
// Get the MinigameRecorder for a certain level
public class MinigameRecorderFactory
{
    private static AbstractMinigameRecorder minigameRecorder;

    public static AbstractMinigameRecorder GetMiniGameRecorderForLevel(int level)
    {
        switch (level)
        {
            case 0:
                return null;
            case 1:
                return new Level1MinigameRecorder();
            case 2:
                return new Level2MinigameRecorder();
            default:
                throw new NoMinigameRecorderForThisLevel();
        }
    }
}