using System;
using UnityEngine;

// Controllers for each level should extend this class
public abstract class AbstractLevelController
{
    // Tags for objects that will always be interacted with should go here
    private enum GlobalTag
    {
        Elevator
    } 

    // This method is called upon interacting with an object (space bar)
    public void Interact(Collider collision)
    {
        try
        {
            GlobalTag tag = (GlobalTag)Enum.Parse(typeof(GlobalTag), collision.gameObject.tag);

            // Load the corresponding scene based on the tag
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

    // Each level controller that subclasses this class will have
    // their own items that they will want to handle interactions for
    protected abstract void InteractHook(Collider collision);

    // Confront the NPC
    public abstract void ColleagueConfrontation();
}