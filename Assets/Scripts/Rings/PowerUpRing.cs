using UniRx;
public class PowerUpRing : RingBase
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        drag.Value = 5f;
        //change drag.value back to 0.5f after 5 seconds
        Observable.Timer(System.TimeSpan.FromSeconds(2)).Subscribe(_ => drag.Value = drag.InitialValue);
        // SlowMotionApplier slowMotionApplier = FindObjectOfType<SlowMotionApplier>();
        // slowMotionApplier.ApplySlowMo();

    }

    public override void OnMissed()
    {
        base.OnMissed();
        ScoreManager.Instance.AddScore(-2);
    }
}
