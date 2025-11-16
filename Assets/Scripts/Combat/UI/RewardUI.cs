using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI dialogueText;
	[SerializeField]
	private Image accesoryImage;

	public void ShowReward(AccesoriesScriptable accesoryData)
	{
		accesoryImage.sprite = accesoryData.spriteFront;
		dialogueText.text = $"¡Julio ha ganado une {accesoryData.accesory}!";
	}
}
