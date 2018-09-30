using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour 
{

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	public float MaxValue { get; set; }

    
	public float Value 
	{
		set 
		{
            fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}

	void Start () 
	{
		
	}
	
	void Update () 
	{
		HandleBar();
	}

	private void HandleBar ()
    {
        if (fillAmount != content.fillAmount) 
        {
            content.fillAmount = fillAmount;        
        }
	}

	private float Map (float value, float inputMin, float inputMax, float outputMin, float outputMax) 
	{
		return (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin) + outputMin;
	}
}
