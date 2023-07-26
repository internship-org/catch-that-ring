public class GoldRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        base.ApplySound();
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-10);
    }
}
