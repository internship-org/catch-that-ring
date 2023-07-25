using UniRx;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    public IntReactiveProperty Score = new IntReactiveProperty(0);
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Score.Subscribe(score =>
        {
            scoreText.text = score.ToString();
            AnimateTextChange(scoreText.gameObject);
        });
    }

    public void AddScore()
    {
        Score.Value += 1;
    }

    public void AddScore(int additionalScore)
    {
        if (Score.Value > 0)
            Score.Value += additionalScore;
    }

    void AnimateTextChange(GameObject textToAnimate)
    {
        textToAnimate.transform
            .DOScale(0.5f, 0.1f)
            .OnComplete(() =>
            {
                textToAnimate.transform.DOScale(Vector3.one, 0.1f);
            });
    }
}
