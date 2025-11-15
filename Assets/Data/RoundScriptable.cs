using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundData")]
public class RoundScriptable : ScriptableObject
{
    public string BossAnswer;
    [SerializeField]
    public List<string> AnswerTexts = new List<string>() { "", "" };
    [SerializeField]
    public List<bool> AnswerCheck = new List<bool>() { false, false };
    [SerializeField]
    public List<Data> Answers;
}

public struct Data
{
    public bool tehe;
    public bool tu;
}
