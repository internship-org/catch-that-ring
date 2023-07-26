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
    // [SerializeField] ParticleSystem starEffect;

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
                // PlayStarEffect();
                LeanPool.Despawn(collider.transform.parent.gameObject);
            })
            .AddTo(this);
    }
    
    // private void PlayStarEffect() {
    //     if(starEffect != null) {
    //         ParticleSystem instance = Instantiate(starEffect, transform.position, Quaternion.identity);
    //         Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    //     }
    // }
}
