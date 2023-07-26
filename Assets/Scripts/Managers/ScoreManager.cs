using UniRx;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    TMP_Text endGameScoreText;

    Tween textTween;

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
            endGameScoreText.text = "Score: " + score.ToString();
        });
    }

    public void AddScore()
    {
        Score.Value += 1;
    }

    public void AddScore(int additionalScore)
    {
        if (Score.Value + additionalScore > 0)
            Score.Value += additionalScore;
    }

    void AnimateTextChange(GameObject textToAnimate)
    {
        textTween = textToAnimate.transform
            .DOScale(0.3f, 0.1f)
            .OnComplete(() =>
            {
                textToAnimate.transform.DOScale(Vector3.one, 0.1f);
            });
    }

    private void OnDisable()
    {
        textTween.Kill();
    }
}
