using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
	[SerializeField]
	private List<RoundScriptable> _rounds;
	[SerializeField]
	private DialogueUI _dialogueUI;
	[SerializeField]
	private StatusBarUI _statusBar;

	private int _currentRound;

	void Start()
	{
		_currentRound = 0;
		_dialogueUI.OnButtonAClicked += () => CheckStatus(0);
		_dialogueUI.OnButtonBClicked += () => CheckStatus(1);
	}

	public void LoadRounds(List<RoundScriptable> rounds)
	{
		_rounds = rounds;
		LoadRound(0);
	}

	private void LoadRound(int round)
	{
		_dialogueUI.UpdateDialogueText(_rounds[round].BossAnswer);
		_dialogueUI.UpdateButtonsText(_rounds[round].AnswerTexts);
	}

	private void CheckStatus(int choice)
	{
		_currentRound++;

		bool result = _rounds[_currentRound].AnswerCheck[choice];

		_statusBar.AddAmount(result ? 1 : -1);

		if (_currentRound < _rounds.Count)
		{
			LoadRound(_currentRound);
		}
		else
		{
			//CheckWin
		}
	}
}