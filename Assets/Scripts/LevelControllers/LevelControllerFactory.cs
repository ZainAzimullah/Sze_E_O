﻿using System;

// Factory Pattern used here
// Get the right LevelController for a given level
public class LevelControllerFactory
{
    public static AbstractLevelController GetInteractionController(int currentLevel)
    {
        switch (currentLevel)
        {
            case 0:
                return new Level0Controller();
            case 1:
                return new Level1Controller();
            case 2:
                return new Level2Controller();
            case 3:
                return new Level3Controller();
        }

        throw new NoInteractionControllerForThisLevelException();
    }
}