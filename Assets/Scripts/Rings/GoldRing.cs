public class GoldRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        GoldManager.Instance.AddGold(1);
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-10);
    }
}
