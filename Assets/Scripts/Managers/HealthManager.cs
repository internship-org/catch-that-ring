using UnityAtoms.BaseAtoms;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable Health;
    public static HealthManager Instance;

    public bool IsDead => Health.Value <= 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AlterHealth(int amount)
    {
        Health.Value += amount;
        if (Health.Value <= 0)
        {
            Health.Value = 0;
            Die();
        }
    }

    void Die() { }
}
