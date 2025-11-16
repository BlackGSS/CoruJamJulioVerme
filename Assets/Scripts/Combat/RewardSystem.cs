using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
	[SerializeField]
	private RewardUI _rewardUI;
	[SerializeField]
	private AccesoriesScriptable[] _accesoriesData;

	private void Start()
	{
		_rewardUI.gameObject.SetActive(false);
	}

	public void WinNextReward()
	{
		Player.diggingStrength += 2f;
		Accesories accesory = (Accesories)Player.Accesories.Count;
		AccesoriesScriptable accesoryData = _accesoriesData.First(x => x.accesory == accesory);
		Player.Accesories.Add(accesory);

		_rewardUI.gameObject.SetActive(true);
		_rewardUI.ShowReward(accesoryData);
	}
}
