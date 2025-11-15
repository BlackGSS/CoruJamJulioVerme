using System;
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

	public Action RoundsCompleted;

	void Start()
	{
		_currentRound = 0;
		_dialogueUI.OnButtonAClicked += () => CheckStatus(0);
		_dialogueUI.OnButtonBClicked += () => CheckStatus(1);
	}

	public void LoadRounds(List<RoundScriptable> rounds)
	{
		_rounds = rounds;
		LoadRound(0, true);
	}

	private void LoadRound(int round, bool successfull)
	{
		_dialogueUI.UpdateDialogueText(successfull ? _rounds[round].BossGoodAnswer : _rounds[round].BossBadAnswer);
		_dialogueUI.UpdateButtonsText(_rounds[round].AnswerTexts);
	}

	private void CheckStatus(int choice)
	{
		bool roundSuccessfull = _rounds[_currentRound].AnswerCheck[choice];
		_statusBar.AddAmount(roundSuccessfull ? 1 : -1);

		_currentRound++;
		if (_currentRound <= _rounds.Count - 1)
		{
			LoadRound(_currentRound, roundSuccessfull);
		}
		else
		{
			StartCoroutine(CompleteRounds());
		}
	}

	IEnumerator CompleteRounds()
	{
		yield return new WaitForEndOfFrame();
		RoundsCompleted?.Invoke();
	}
}