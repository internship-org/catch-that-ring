using System.Data;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
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
                collider.gameObject.GetComponent<RingBase>().OnMissed();
            })
            .AddTo(this);
    }
}
