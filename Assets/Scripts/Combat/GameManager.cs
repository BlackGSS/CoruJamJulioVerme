using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BossScriptable _bossScriptable;
    private RoundSystem _roundSystem;

    private StatusBarUI _statusBar;

    // Start is called before the first frame update
    void Start()
    {
        _statusBar.SetBossName(_bossScriptable.BossName);
        _roundSystem.LoadRounds(_bossScriptable.Rounds);
    }

    public void CheckWin()
    {
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
