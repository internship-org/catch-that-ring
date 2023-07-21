using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RingBase : MonoBehaviour
{
    protected float dropChance;

    protected abstract void ApplyEffect();
}
