public class HealthRing : RingBase
{
    public override void ApplyEffect()
    {
        HealthManager.Instance.AlterHealth(1);
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-1);
    }
}
