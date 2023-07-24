public class GoldRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-10);
    }
}
