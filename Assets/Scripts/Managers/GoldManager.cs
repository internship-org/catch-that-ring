using UnityAtoms.BaseAtoms;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable playerGold;

    public static GoldManager Instance;

    [SerializeField]
    TMP_Text goldText;

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

    private void Start() { }

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

    public void EarnEndGameGolds()
    {
        var additionGold = (int)(ScoreManager.Instance.Score.Value * 0.1f);
        playerGold.Value += additionGold;
        goldText.text = "Gold  +" + playerGold.Value.ToString();
    }
}
