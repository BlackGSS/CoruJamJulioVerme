// ===================================================
// Author: Kadrius
// ===================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    [SerializeField]
    protected CanvasGroup background;
    [SerializeField]
    protected RocksController rocksController;

    protected int rocksNumber;

    protected void Awake()
    {
        rocksNumber = rocksController.GetRocksNumber();
    }

    protected void ChangeBackgroundVisibility()
    {
        //background.DOFade()
    }

}
