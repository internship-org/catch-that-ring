using UnityEngine;
public abstract class RingBase : MonoBehaviour
{
    [SerializeField]
    protected int worthPoints = 0;
    [SerializeField]
    public float dropChance = 0f;

    public abstract void ApplyEffect();

    public abstract void OnMissed();
}
