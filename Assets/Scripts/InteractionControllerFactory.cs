using System;

public class InteractionControllerFactory
{
    public static AbstractInteractionController GetInteractionController(int currentLevel)
    {
        switch (currentLevel)
        {
            case 0:
                return new Level0InteractionController();
            case 1:
                return new Level1InteractionController();
            case 2:
                return new Level2InteractionController();
        }

        throw new NoInteractionControllerForThisLevelException();
    }
}