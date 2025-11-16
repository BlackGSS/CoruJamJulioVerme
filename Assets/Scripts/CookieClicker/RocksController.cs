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
    protected int remainingRocks;

    #region Monobehaviour Methods

    protected virtual void Awake()
    {
        group = GetComponent<GridLayoutGroup>();
        rocks = group.GetComponentsInChildren<RockBehaviour>().ToList();
        remainingRocks = rocks.Count;
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
        int[] ints = new int[rocks.Count];
        for (int i = 0; i < rocks.Count; i++)
        {
            ints[i] = i+1;
        }

        int[] shufledInts = Shuffle(ints);

        for (int i = 0; i < rocks.Count; i++)
        {
            var rock = rocks[i];
            rock.ChangeImage(rockSprites[Random.Range(0,rockSprites.Count)]);
            rock.SetOrder(shufledInts[i]);
        }
    }

    protected void BreakRock(RockBehaviour rock)
    {
        //TODO Hacer algo más?
        OnBreakRock?.Invoke();
        remainingRocks--;
        if (remainingRocks <= 0)
            OnBreakAllRocks?.Invoke();
    }

    protected void Addlisteners()
    {
        foreach(var rock in rocks)
        {
            rock.OnBreakRock += BreakRock;
        }
    }

    // probably "static" should be added (depends on GenerateAnotherNum routine)
    public int[] Shuffle(int[] Sequence)
    {
        // public method's arguments validation
        if (null == Sequence)
            throw new ArgumentNullException(nameof(Sequence));

        // No need in Array if you want to modify Sequence

        for (int s = 0; s < Sequence.Length - 1; s++)
        {
            int GenObj = Random.Range(s, Sequence.Length); // pleace, note the range

            // swap procedure: note, var h to store initial Sequence[s] value
            var h = Sequence[s];
            Sequence[s] = Sequence[GenObj];
            Sequence[GenObj] = h;
        }

        return Sequence;
    }
    #endregion
}
