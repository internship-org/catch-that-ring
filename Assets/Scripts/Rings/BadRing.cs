using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UniRx;
using UnityEngine;

public class BadRing : RingBase
{
    public override void ApplyEffect()
    {
        //decrease healtj and score(coin?)
    }

    public override void OnMissed()
    {
        ScoreManager.Instance.AddScore(-1);
        LeanPool.Despawn(this.transform.parent.gameObject);
    }
}
