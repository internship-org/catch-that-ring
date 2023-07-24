using UnityAtoms.BaseAtoms;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

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
                GetComponent<Image>().fillAmount = 1.0f * health / Health.InitialValue;
                print("ASDADSA");
            });

        Observable
            .EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => Health.Value -= 1);
    }
}
