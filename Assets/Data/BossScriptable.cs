using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossData")]
public class BossScriptable : ScriptableObject
{
	public string BossName;
	public Sprite BossImage;
	public List<RoundScriptable> Rounds;

	public List<string> InitialText;
	public string SuccessfullCombatText;
	public string BadCombatText;
	public List<string> FinalTexts;
}
