public class HealthRing : RingBase
{
    public override void ApplyEffect()
    {
        HealthManager.Instance.AlterHealth(1);
        ApplySound();
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-1);
    }
    public override void ApplySound()
    {
        AudioPlayer.Instance.PlayHealSound();
    }
}
