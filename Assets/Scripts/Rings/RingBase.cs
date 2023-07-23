using UnityEngine;

public abstract class RingBase : MonoBehaviour
{
    [SerializeField]
    protected int worthPoints = 0;

    [SerializeField]
    public abstract float dropChance { get; set; }

    public abstract void ApplyEffect();

    public abstract void OnMissed();
}
