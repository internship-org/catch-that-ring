using UnityAtoms.BaseAtoms;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private IntVariable Health;

    Tween barTween;

    private void Awake()
    {
        Health.Value = Health.InitialValue;
    }

    private void Start()
    {
        Health
            .ObserveChange()
            .Subscribe(health =>
            {
                var healthBarImage = GetComponent<Image>();
                barTween = DOTween.To(
                    () => healthBarImage.fillAmount,
                    x => healthBarImage.fillAmount = x,
                    1.0f * health / Health.InitialValue,
                    1f
                );
                if (health < 2)
                {
                    healthBarImage.DOColor(Color.red, 1f);
                }
                else if (health < 4)
                {
                    healthBarImage.DOColor(Color.yellow, 1f);
                }
                else
                {
                    healthBarImage.DOColor(Color.green, 1f);
                }
            })
            .AddTo(this);

        Observable
            .EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => Health.Value -= 1);
    }

    private void OnDisable()
    {
        barTween.Kill();
    }
}
