using System;
using UnityEngine;

public abstract class AbstractLevelController
{
    private enum GlobalTag
    {
        Elevator
    }

    public void Interact(Collider collision)
    {
        try
        {
            GlobalTag tag = (GlobalTag)Enum.Parse(typeof(GlobalTag), collision.gameObject.tag);

            switch (tag)
            {
                case GlobalTag.Elevator:
                    SceneTransitionManager.Instance.LoadScene(SceneEnum.Elevator);
                    break;
            }
        } catch (ArgumentException)
        {
            InteractHook(collision);
        }
    }

    protected abstract void InteractHook(Collider collision);
    public abstract void ColleagueConfrontation();
}