using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BossData")]
public class BossScriptable : ScriptableObject
{
	public string BossName;
	public Image BossImage;
	public List<RoundScriptable> Rounds;
}
