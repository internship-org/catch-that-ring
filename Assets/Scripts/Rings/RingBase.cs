using Lean.Pool;
using UnityEngine;

public abstract class RingBase : MonoBehaviour
{
    [SerializeField]
    protected int worthPoints = 0;

    [SerializeField]
    public float dropChance = 0f;

    public virtual void ApplyEffect()
    {
        ScoreManager.Instance.AddScore(worthPoints);
    }

    public virtual void OnMissed()
    {
        LeanPool.Despawn(gameObject);
    }
}
