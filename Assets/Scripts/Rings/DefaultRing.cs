using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRing : RingBase
{
    public override void ApplyEffect()
    {
        ScoreManager.Instance.AddScore(1);
    }

    public override void OnMissed()
    {
        ScoreManager.Instance.AddScore(-1);
    }
    
    public override float dropChance { get; set; } = 0.5f;
}
