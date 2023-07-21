using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RingCollecter : MonoBehaviour { 

    Collider ringCollectTrigger;
    private void Awake() {
        ringCollectTrigger = GetComponent<Collider>();
    }
    private void Start() {
        ringCollectTrigger.OnTiggerEnterAsObservable()
    }
}
