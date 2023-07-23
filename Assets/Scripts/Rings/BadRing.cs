using Lean.Pool;

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

    public override float dropChance { get; set; } = 0.3f;
}
