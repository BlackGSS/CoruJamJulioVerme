// ===================================================
// Author: Kadrius
// ===================================================

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockBehaviour : MonoBehaviour
{
    public Action<RockBehaviour> OnBreakRock;

    public float life = 100f;
    protected Button button;
    protected Canvas canvas;
    protected Tweener tween;

    protected void Awake()
    {
        canvas = GetComponent<Canvas>();
        button = GetComponent<Button>();
        button.onClick.AddListener(HitRock);
        tween = transform.DOShakePosition(.3f, 10f, 40, 150).SetAutoKill(false).Pause();
        button.image.alphaHitTestMinimumThreshold = 0.1f;
    }

    public void ChangeImage(Sprite sprite)
    {
        button.image.sprite = sprite;
    }

    public void SetOrder(int order)
    {
        canvas.sortingOrder = order;
    }

    protected void HitRock() 
    {
        life -= Player.diggingStrength;

        if (!tween.IsPlaying())
        {
            tween.Kill();
            tween = transform.DOShakePosition(.3f, 10f, 40, 150).SetAutoKill(false).Play();
        }

        if (life <= 0)
        {
            OnBreakRock?.Invoke(this);
            HideRock();
        } 
    }

    protected void HideRock()
    {
        //TODO cambiar esto una animación de romperse?
        gameObject.SetActive(false);
    }
}
