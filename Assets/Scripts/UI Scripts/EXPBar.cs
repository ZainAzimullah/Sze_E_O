using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour {

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;


	void Start () 
	{
		
	}
	
	void Update () 
	{
		HandleBar();
	}

	private void HandleBar ()
	{
		content.fillAmount = Map(15, 0, 100, 0, 1);	
	}

	private float Map (float value, float inputMin, float inputMax, float outputMin, float outputMax) 
	{
		return (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin) + outputMin;
	}
}
