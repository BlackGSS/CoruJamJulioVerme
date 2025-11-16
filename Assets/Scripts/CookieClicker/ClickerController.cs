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
    protected Image boss;
    [SerializeField]
    protected RocksController rocksController;

    protected int rocksNumber;
    protected float fadeAmmount = 1f;
    protected Color fadeColor = Color.black;

    protected void Start()
    {
        rocksNumber = rocksController.GetRocksNumber();
        Addlisteners();
    }

    protected void Addlisteners()
    {
        rocksController.OnBreakRock += ChangeBackgroundVisibility;
        rocksController.OnBreakAllRocks += ShowBoss;
    }

    protected void ChangeBackgroundVisibility()
    {
        fadeAmmount -= (1f / rocksNumber);
        CalculateFadeColor();
        background.DOColor(fadeColor, .5f);
        boss.DOColor(fadeColor, .5f);
    }

    protected void ShowBoss()
    {
        //Do some animation and emit some sound
        //and fade to black to next scene
    }

    protected void CalculateFadeColor()
    {
        float colorValue = (1f - fadeAmmount);
        fadeColor = new Color(colorValue, colorValue, colorValue);
    }
}
