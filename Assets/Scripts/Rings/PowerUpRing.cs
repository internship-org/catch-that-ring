public class PowerUpRing : RingBase
{
    public override void ApplyEffect()
    {
        ScoreManager.Instance.AddScore(1);
    }

    public override void OnMissed()
    {
        ScoreManager.Instance.AddScore(-1);
    }

    public override float dropChance { get; set; } = 0.15f;
}
