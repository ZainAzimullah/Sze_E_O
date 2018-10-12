using System;

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
        }

        throw new NoInteractionControllerForThisLevelException();
    }
}