// ===================================================
// Author: Kadrius
// ===================================================

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

    protected void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HitRock);
    }

    protected void HitRock() 
    {
        life -= Player.diggingStrength;
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
