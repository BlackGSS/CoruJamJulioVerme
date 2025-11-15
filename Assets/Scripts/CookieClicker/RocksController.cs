// ===================================================
// Author: Kadrius
// ===================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RocksController : MonoBehaviour
{
    public Action OnBreakRock;
    public Action OnBreakAllRocks;

    protected GridLayoutGroup group;
    protected List<RockBehaviour> rocks;

    protected virtual void Awake()
    {
        group = GetComponent<GridLayoutGroup>();
        rocks = group.GetComponentsInChildren<RockBehaviour>().ToList();
    }

    protected void Start()
    {
        SetupRocks();
    }

    protected void SetupRocks()
    {
        RandomizeRotation();
    }

    protected void RandomizeRotation()
    {
        foreach (var rock in rocks)
        {
            Quaternion rotation = Random.rotation;
            rock.transform.localRotation = rotation;
        }
    }

    protected void Addlisteners()
    {

    }
}
