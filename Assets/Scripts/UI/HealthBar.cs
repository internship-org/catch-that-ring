using UnityAtoms.BaseAtoms;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private IntVariable health;
    Image healthBarImage;

    Tween barTween;
    Tween colorTween;

    private void Awake()
    {
        health.Value = health.InitialValue;
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
            1.0f * health.Value / health.InitialValue,
            1f
        );
    }

    public void AnimateBarColor()
    {
        if (health.Value < 2)
        {
            colorTween = healthBarImage.DOColor(Color.red, 1f);
        }
        else if (health.Value < 4)
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
