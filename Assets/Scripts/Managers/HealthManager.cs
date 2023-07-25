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
        if (Health.Value > 0)
            Health.Value += amount;
    }

    public void Die()
    {
        print("you dead");
    }
}
