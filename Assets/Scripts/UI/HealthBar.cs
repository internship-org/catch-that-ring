using UnityAtoms.BaseAtoms;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private IntVariable Health;

    [SerializeField]
    private IntConstant MaxHealth;

    private void Start()
    {
        Health
            .ObserveChange()
            .Subscribe(health =>
            {
                var healthBarImage = GetComponent<Image>();
                DOTween.To(
                    () => healthBarImage.fillAmount,
                    x => healthBarImage.fillAmount = x,
                    1.0f * health / Health.InitialValue,
                    0.5f
                );
                if (health < 2)
                {
                    healthBarImage.DOColor(Color.red, 0.5f);
                }
                else if (health < 4)
                {
                    healthBarImage.DOColor(Color.yellow, 0.5f);
                }
            });

        Observable
            .EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => Health.Value -= 1);
    }
}
