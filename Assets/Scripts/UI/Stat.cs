using System;
using UnityEngine;

[Serializable]
public class Stat 
{
    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

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

    public void Initialize () 
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
