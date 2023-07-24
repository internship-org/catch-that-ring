using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class RingCollecter : MonoBehaviour
{
    [SerializeField]
    Collider ringCollectTrigger;
    private string ringTag = "RingTrigger";

    private void Awake()
    {
        ringCollectTrigger = GetComponent<Collider>();
    }

    private void Start()
    {
        ringCollectTrigger
            .OnTriggerEnterAsObservable()
            .Where(collider => collider.CompareTag(ringTag))
            .Subscribe(collider =>
            {
                collider.GetComponentInParent<RingBase>().ApplyEffect();
                LeanPool.Despawn(collider.transform.parent.gameObject);
            })
            .AddTo(this);
    }
}