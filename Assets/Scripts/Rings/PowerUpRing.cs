public class PowerUpRing : RingBase
{
    private TimeManager timeManager;

    private void Start() {
        timeManager = FindObjectOfType<TimeManager>();
    }
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        timeManager.DoSlowmotion();
        
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-2);
    }
}
