using System;
using System.Data;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CatchMisses : MonoBehaviour
{
    [SerializeField]
    private Collider ringMissCollider;
    private string ringTag = "RingTrigger";

    private void Awake()
    {
        ringMissCollider = GetComponent<Collider>();
    }

    void Start()
    {
        ringMissCollider
            .OnTriggerEnterAsObservable()
            .Where(collider => collider.CompareTag(ringTag))
            .Subscribe(collider =>
            {
                collider.gameObject.GetComponentInParent<RingBase>().OnMissed();
            })
            .AddTo(this);
    }
}
