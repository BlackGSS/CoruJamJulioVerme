using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private BossPerRoundScriptable _bossPerRoundScriptable;
	[SerializeField]
	private RoundSystem _roundSystem;
	[SerializeField]
	private StatusBarUI _statusBar;
	[SerializeField]
	private ChoiceDialogueUI _choiceDialogueUI;
	[SerializeField]
	private DialogueUI _dialogueUI;
	[SerializeField]
	private Image _bossImage;

	void Start()
	{
		BossScriptable bossScriptable = _bossPerRoundScriptable.BossPerRound[Player.combatRound];
		_dialogueUI.onCompleteTexts += InitializeCombat;

		_statusBar.SetBossName(bossScriptable.BossName);
		_bossImage.sprite = bossScriptable.BossImage;
		_choiceDialogueUI.gameObject.SetActive(false);
		_dialogueUI.ShowDialogue(bossScriptable.InitialText);
	}

	public void CheckWin()
	{
		_choiceDialogueUI.gameObject.SetActive(false);
		List<string> finalTexts = new();
		BossScriptable bossScriptable = _bossPerRoundScriptable.BossPerRound[Player.combatRound];
		bool win = _statusBar.GetSliderValue > 0;

		finalTexts.Add(win ? bossScriptable.SuccessfullCombatText : bossScriptable.BadCombatText);

		if (bossScriptable.FinalTexts.Count > 0)
			finalTexts.AddRange(bossScriptable.FinalTexts);

		_dialogueUI.gameObject.SetActive(true);
		_dialogueUI.ShowDialogue(finalTexts);
		_dialogueUI.onCompleteTexts += win ? EarnReward : EndCombat;
	}

	private void InitializeCombat()
	{
		_dialogueUI.gameObject.SetActive(false);

		_choiceDialogueUI.gameObject.SetActive(true);

		BossScriptable bossScriptable = _bossPerRoundScriptable.BossPerRound[Player.combatRound];
		_roundSystem.LoadRounds(bossScriptable.Rounds);
		_roundSystem.RoundsCompleted += CheckWin;

		_dialogueUI.onCompleteTexts -= InitializeCombat;
	}

	private void EndCombat()
	{
		Player.combatRound++;
		_dialogueUI.gameObject.SetActive(false);
		_dialogueUI.onCompleteTexts -= EndCombat;
		//FadeOut y
		//Cargar siguiente escena
	}

	private void EarnReward()
	{
		_dialogueUI.gameObject.SetActive(false);
		//Show reward UI
	}
}
