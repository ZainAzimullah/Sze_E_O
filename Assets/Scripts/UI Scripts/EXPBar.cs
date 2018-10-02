using System;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{

	private static readonly float TOLERANCE = 0.01f;
	
	
	
	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	public float MaxValue { get; set; }

	private void Start()
	{
		fillAmount = PlayerManager.Instance.GetExperience().CurrentVal;
	}

	public float Value 
	{
		set { fillAmount = value / PlayerManager.Instance.GetExperience().MaxVal; }
		get { return fillAmount; }
	}
	
	void Update () 
	{
        Value = PlayerManager.Instance.GetExperience().CurrentVal;

		content.fillAmount = Value;
		Debug.Log(content.fillAmount);
		
    }

	private static float Map (float value, float inputMin, float inputMax, float outputMin, float outputMax) 
	{
//		Debug.Log(value +  "Value");
//		Debug.Log(inputMin + "input Min");
//		Debug.Log(inputMax + "input Max");
//		Debug.Log(outputMin + "output Min");
//		Debug.Log(outputMax + "output Max");

		return (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin) + outputMin;
		
		
	}
}
