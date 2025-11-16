using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Texts Data", menuName = "Texts Data")]
public class TextScriptable : ScriptableObject
{
	public List<string> textsToLoad;
}
