using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossPerRoundData")]
public class BossPerRoundScriptable : ScriptableObject
{
	[SerializeField]
	public List<BossScriptable> BossPerRound;
}
