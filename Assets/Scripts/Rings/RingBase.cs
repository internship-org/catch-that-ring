using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RingBase : MonoBehaviour
{
    [SerializeField]
    protected int worthPoints = 0;

    [SerializeField]
    protected float dropChance;

    public abstract void ApplyEffect();
    public abstract void OnMissed();
}
