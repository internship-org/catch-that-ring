public class DefaultRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        base.ApplySound();
    }

    public override void OnMissed()
    {
        base.OnMissed();
        AudioPlayer.Instance.PlayMissingSound();
        HealthManager.Instance.AlterHealth(-1);
        ScoreManager.Instance.AddScore(-2);
    }
}
