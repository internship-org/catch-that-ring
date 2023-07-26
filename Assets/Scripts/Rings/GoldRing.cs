public class GoldRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        base.ApplySound();
        GoldManager.Instance.AddGold(1);
    }

    public override void OnMissed()
    {
        base.OnMissed();
    }
}
