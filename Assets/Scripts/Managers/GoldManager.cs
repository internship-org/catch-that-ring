using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable playerGold;
    public static GoldManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public bool IsGoldEnough(int amount)
    {
        if (playerGold.Value - amount >= 0)
            return true;
        else
            return false;
    }

    public void SpendGold(int amount)
    {
        if (IsGoldEnough(amount))
            playerGold.Value -= amount;
    }

    public void AddGold(int amount)
    {
        playerGold.Value += amount;
    }
}
