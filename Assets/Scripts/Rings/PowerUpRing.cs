using UniRx;
public class PowerUpRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        ApplySound();
        drag.Value = 5f;
        Observable.Timer(System.TimeSpan.FromSeconds(2)).Subscribe(_ => drag.Value = drag.InitialValue);

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
