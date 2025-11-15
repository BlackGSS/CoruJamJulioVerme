using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BossPerRoundScriptable _bossPerRoundScriptable;
    [SerializeField]
    private RoundSystem _roundSystem;
    [SerializeField]
    private StatusBarUI _statusBar;
    [SerializeField]
    private DialogueUI _dialogueUI;

    void Start()
    {
        BossScriptable bossScriptable = _bossPerRoundScriptable.BossPerRound[Player.combatRound];

        _statusBar.SetBossName(bossScriptable.BossName);

        _dialogueUI.ShowChoiceButtons(true);
        _roundSystem.LoadRounds(bossScriptable.Rounds);
        _roundSystem.RoundsCompleted += CheckWin;
    }

    public void CheckWin()
    {
        _dialogueUI.ShowChoiceButtons(false);
        Player.combatRound++;
        if (_statusBar.GetSliderValue > 0)
        {
            //Win
        }
        else
        {
            //Loose
        }
    }
}
