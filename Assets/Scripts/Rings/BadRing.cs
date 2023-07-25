using Lean.Pool;

public class BadRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        HealthManager.Instance.AlterHealth(-3);
    }

    public override void OnMissed()
    {
        base.OnMissed();
    }
}
