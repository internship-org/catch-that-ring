public class PowerUpRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        SlowMotionApplier slowMotionApplier = FindObjectOfType<SlowMotionApplier>();
        slowMotionApplier.ApplySlowMo();
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-2);
    }
}
