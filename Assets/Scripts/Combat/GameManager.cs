using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BossScriptable _bossScriptable;
    [SerializeField]
    private RoundSystem _roundSystem;
    [SerializeField]
    private StatusBarUI _statusBar;

    // Start is called before the first frame update
    void Start()
    {
        _statusBar.SetBossName(_bossScriptable.BossName);

        _roundSystem.LoadRounds(_bossScriptable.Rounds);
        _roundSystem.RoundsCompleted += CheckWin;
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
