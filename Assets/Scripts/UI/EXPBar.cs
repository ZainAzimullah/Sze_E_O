using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	// the max value of experience will be 100, 
	public float MaxValue { get; set; }

	private void Start()
	{
		// On scene start get Current EXP
		fillAmount = PlayerManager.Instance.GetExperience().CurrentVal;
	}

	// value property, represents how much of the exp bar will be filled
	public float Value 
	{
		set { fillAmount = value / PlayerManager.Instance.GetExperience().MaxVal; }
		get { return fillAmount; }
	}
	
	void Update () 
	{
		// gets the experience from the singleton to update the exp bar to the correct value
        Value = PlayerManager.Instance.GetExperience().CurrentVal;
		content.fillAmount = Value;
    }

}
