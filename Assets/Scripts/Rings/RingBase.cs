using Lean.Pool;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UniRx;

public abstract class RingBase : MonoBehaviour
{
    [SerializeField]
    protected FloatVariable drag;
    [SerializeField]
    protected int worthPoints = 0;

    [SerializeField]
    public float dropChance = 0f;
    Rigidbody rb;
    public AudioPlayer audioPlayer;

    private void Awake() {
        OnStart();
    }

    public virtual void ApplyEffect()
    {
        ScoreManager.Instance.AddScore(worthPoints);
    }

    public virtual void OnMissed()
    {
        LeanPool.Despawn(gameObject);
    }

    public virtual void ApplySound() {
        AudioPlayer.Instance.PlayCatchingSound();
    }

    protected void OnStart() {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag.Value;
        drag.ObserveChange().Subscribe(newDrag =>
        {
            rb.drag = newDrag;
        }).AddTo(this);
    }
}
