using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarUI : MonoBehaviour
{
    [SerializeField]
    private Slider _statusBar;
    [SerializeField]
    private TextMeshProUGUI _bossNameText;

	void Start()
    {
        _statusBar.value = 0;
    }

    public int GetSliderValue { get { return (int)_statusBar.value; } }

    public void AddAmount(int amount)
    {
        _statusBar.value += amount;
    }

    public void SetBossName(string name)
    {
        _bossNameText.text = name;
    }
}
