// ===================================================
// Author: Kadrius
// ===================================================

using DG.Tweening;
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
    public AudioSource audioSource;
    public List<Sprite> rockSprites = new List<Sprite>();

    protected GridLayoutGroup group;
    protected List<RockBehaviour> rocks;

    #region Monobehaviour Methods

    protected virtual void Awake()
    {
        group = GetComponent<GridLayoutGroup>();
        rocks = group.GetComponentsInChildren<RockBehaviour>().ToList();
    }

    protected void Start()
    {
        SetupRocks();
        DOVirtual.DelayedCall(.5f,() => group.enabled = false);
    }

    #endregion

    #region Public Methods

    public int GetRocksNumber()
    {
        return rocks.Count;
    }

    #endregion

    #region protected Methods

    protected void SetupRocks()
    {
        RandomizeRotation();
        RandomizeAspect();
        Addlisteners();
    }

    protected void RandomizeRotation()
    {
        foreach (var rock in rocks)
        {
            float rotation = Random.Range(0f, 360f);
            Vector3 euler = rock.transform.localRotation.eulerAngles;
            euler.z = rotation;
            rock.transform.localRotation = Quaternion.Euler(euler);
        }
    }

    protected void RandomizeAspect()
    {
        foreach (var rock in rocks)
        {
            rock.ChangeImage(rockSprites[Random.Range(0,rockSprites.Count)]);
            rock.SetOrder(Random.Range(1,rockSprites.Count));
        }
    }

    protected void BreakRock(RockBehaviour rock)
    {
        //TODO Hacer algo más?
        OnBreakRock?.Invoke();
    }

    protected void Addlisteners()
    {
        foreach(var rock in rocks)
        {
            rock.OnBreakRock += BreakRock;
        }
    }
    #endregion
}
