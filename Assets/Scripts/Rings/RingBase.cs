using UnityEngine;

public abstract class RingBase : MonoBehaviour
{
    [SerializeField]
    protected int worthPoints = 0;

    [SerializeField]
    protected float dropChance = 1f;

    public abstract void ApplyEffect();

    public abstract void OnMissed();
}
