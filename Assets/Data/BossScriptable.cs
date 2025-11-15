using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossData")]
public class BossScriptable : ScriptableObject
{
	public string BossName;
	public List<RoundScriptable> Rounds;
}
