using UnityAtoms.BaseAtoms;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable playerGold;

    public static GoldManager Instance;
    int additionalGold = 0;

    [SerializeField]
    TMP_Text goldText;

    private void Awake()
    {
        Instance = this;
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
        additionalGold += amount;
        playerGold.Value += amount;
    }

    public void EarnEndGameGolds()
    {
        //extra gold at each 20 points
        additionalGold += (int)(ScoreManager.Instance.Score.Value * 0.05f);
        playerGold.Value += additionalGold;
        goldText.text = "Gold  +" + additionalGold.ToString();
    }
}
