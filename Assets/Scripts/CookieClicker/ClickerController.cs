// ===================================================
// Author: Kadrius
// ===================================================

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    [SerializeField]
    protected Image background;
    [SerializeField]
    protected Image bossImage;
    [SerializeField]
    protected RocksController rocksController;
    [SerializeField]
    protected List<BossScriptable> bossScriptables;
    [SerializeField]
    protected GameObject clickTutorial;
    [SerializeField]
    protected DialogueUI dialogueUI;
    [SerializeField]
    protected SceneManagement sceneManagement;
    [SerializeField]
    protected string nextSceneName = "Combat";
    [SerializeField]
    protected AudioSource combatTransitionMusic;

    protected int rocksNumber;
    protected int rockIndex = 1;
    protected float fadeAmmount = 1f;
    protected Color fadeColor = Color.black;

    protected void Start()
    {
        rocksNumber = rocksController.GetRocksNumber();
        SetupBossData(Player.combatRound);
        Addlisteners();
        if (Player.combatRound != 0)
        {
            clickTutorial.SetActive(false);
            dialogueUI.gameObject.SetActive(false);
        }            
    }

    protected void Addlisteners()
    {
        rocksController.OnBreakRock += ChangeBackgroundVisibility;
        rocksController.OnBreakAllRocks += ShowBoss;
    }

    protected void ChangeBackgroundVisibility()
    {
        clickTutorial.SetActive(false);
        fadeAmmount -= CalculateFadeAmmount();
        CalculateFadeColor();
        background.DOColor(fadeColor, .0f);
        bossImage.DOColor(fadeColor, .0f);
    }

    protected void ShowBoss()
    {
        //Do some animation and emit some sound
        //and fade to black to next scene

        background.DOColor(Color.white, .5f);
        bossImage.DOColor(Color.white, .5f);
        combatTransitionMusic.Play();
        
        DOVirtual.DelayedCall(2f, () => 
        {
            combatTransitionMusic.DOFade(0f, 2f);
            sceneManagement.NextScene();
        });
    }

    protected float CalculateFadeAmmount()
    {
        return (0.4f / rocksNumber);
    }

    protected void CalculateFadeColor()
    {
        float colorValue = (1f - fadeAmmount);
        fadeColor = new Color(colorValue, colorValue, colorValue);
    }

    protected void SetupBossData(int round)
    {
        bossImage.sprite = bossScriptables[round].BossImage;
    }
}
