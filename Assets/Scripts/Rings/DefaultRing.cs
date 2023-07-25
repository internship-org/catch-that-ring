public class DefaultRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
    }

    public override void OnMissed()
    {
        base.OnMissed();
        HealthManager.Instance.AlterHealth(-1);
        ScoreManager.Instance.AddScore(-2);
    }
}
