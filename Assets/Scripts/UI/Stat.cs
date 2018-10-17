using System;
using UnityEngine;

[Serializable]
public class Stat 
{
    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

	// property for the amount of experience
    public float CurrentVal
    {
        get 
        {
            return currentVal;
        }
        set 
        {
            // Prevents EXP from going over minimum and maximum values
            currentVal = Mathf.Clamp(value, 0, MaxVal); 
        }
    }

	// property to set the max exp a user can get, which will be 100 in the player manager
	// singleton class
    public float MaxVal 
    {
        get 
        {
            return maxVal;
        }
        set
        {
            maxVal = value;
        }
    }

	// set the exp annd maximum value
    public void Initialize () 
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
