using UnityAtoms.BaseAtoms;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private IntVariable Health;
    Image healthBarImage;

    Tween barTween;
    Tween colorTween;

    private void Awake()
    {
        Health.Value = Health.InitialValue;
    }

    private void Start()
    {
        healthBarImage = GetComponent<Image>();
    }

    public void AnimateHealthBar()
    {
        barTween = DOTween.To(
            () => healthBarImage.fillAmount,
            x => healthBarImage.fillAmount = x,
            1.0f * Health.Value / Health.InitialValue,
            1f
        );
    }

    public void AnimateBarColor()
    {
        if (Health.Value < 2)
        {
            colorTween = healthBarImage.DOColor(Color.red, 1f);
        }
        else if (Health.Value < 4)
        {
            colorTween = healthBarImage.DOColor(Color.yellow, 1f);
        }
        else
        {
            colorTween = healthBarImage.DOColor(Color.green, 1f);
        }
    }

    private void OnDisable()
    {
        colorTween.Kill();
        barTween.Kill();
    }
}
