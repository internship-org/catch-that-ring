using Lean.Pool;

public class BadRing : RingBase
{   
    private void Awake() {
        OnStart();
    }
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        ApplySound();
        HealthManager.Instance.AlterHealth(-3);
    }

    public override void OnMissed()
    {
        base.OnMissed();
    }

    public override void ApplySound()
    {
        AudioPlayer.Instance.PlayMissingSound();
    }
}
