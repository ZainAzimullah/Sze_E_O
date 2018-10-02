using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	public float MaxValue { get; set; }

	private void Start()
	{
		// On scene start get Current EXP
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
    }

}
