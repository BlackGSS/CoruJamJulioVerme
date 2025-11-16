using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JulioSprites")]
public class JulioSpritesScriptable : ScriptableObject
{
	[SerializeField]
	public Sprite[] narrativeSprites;
	[SerializeField]
	public Sprite[] combatSprites;
	[SerializeField]
	public Accesories[] accesoriesSprites;
}