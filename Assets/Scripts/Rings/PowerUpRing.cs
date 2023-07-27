using UniRx;

public class PowerUpRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        ApplySound();
        drag.Value = 5f;
        Observable
            .Timer(System.TimeSpan.FromSeconds(2))
            .Subscribe(_ =>
            {
                drag.Value = drag.InitialValue;
                // Resume spawning after the effect ends
                FindObjectOfType<Spawner>()
                    .ResumeSpawning();
            });
        // Pause spawning during the effect
        FindObjectOfType<Spawner>()
            .EndSpawning();
    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-2);
    }

    public override void ApplySound()
    {
        AudioPlayer.Instance.PlayPowerupSound();
    }
}
