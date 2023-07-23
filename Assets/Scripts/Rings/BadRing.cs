using Lean.Pool;
using UnityEngine;

public class BadRing : RingBase
{
    public override void ApplyEffect()
    {
        ScoreManager.Instance.AddScore(-1);
    }

    public override void OnMissed()
    {
        LeanPool.Despawn(this.transform.parent.gameObject);
    }
}
