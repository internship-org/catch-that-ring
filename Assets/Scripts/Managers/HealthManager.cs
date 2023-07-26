using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable Health;
    public static HealthManager Instance;

    public bool IsDead => Health.Value <= 0;

    public UnityEvent DieEvent;

    private void Awake()
    {
        Instance = this;
    }

    public void AlterHealth(int amount)
    {
        if (Health.Value >= 0)
            Health.Value += amount;
    }

    public void Die()
    {
        DieEvent.Invoke();
    }
}
