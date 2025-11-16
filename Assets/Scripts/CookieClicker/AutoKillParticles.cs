// ===================================================
// Author: Adrián "Kadrius" Blanco
// Email: ablanco@invelon.com
// Date: #DATE#
// Project: #PROJECTNAME#
// ===================================================

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKillParticles : MonoBehaviour
{
    [SerializeField]
    protected ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Awake()
    {
        DOVirtual.DelayedCall(2f, () => Destroy(this.gameObject));
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    void OnParticleSystemStopped()
    {
        Destroy(this.gameObject);
    }
}
