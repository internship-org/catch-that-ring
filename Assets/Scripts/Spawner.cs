using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Lean.Pool;

public class Spawner : MonoBehaviour
{
    private Collider SpawnArea;
    private IDisposable SpawnDisposable;

    private GameObject[] RingPrefabs;
    public GameObject BadRingPrefab;
    [Range(0f, 1f)] public float BadRingChance = 0.05f;
    public float MinSpawnDelay = 0.25f;
    public float MaxSpawnDelay = 1f;
    public float MaxRingLifetime = 5f;

    private void Awake() 
    {
        SpawnArea = GetComponent<Collider>(); 
    }

    private void OnEnable() {
        SpawnDisposable = Observable.FromCoroutine(Spawn)
        .Subscribe()
        .AddTo(this);
    }

    private void OnDisable() {
        SpawnDisposable?.Dispose();
    }

    private IEnumerator Spawn() 
    {
        yield return new WaitForSeconds(2f);

        while(enabled) 
        {
            GameObject Prefab = RingPrefabs[UnityEngine.Random.Range(0, RingPrefabs.Length)];

            if(UnityEngine.Random.value <  BadRingChance)
            {
                Prefab = BadRingPrefab;
            }

            Vector3 Position = new Vector3();
            Position.x = UnityEngine.Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x);
            Position.y = UnityEngine.Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);
            Position.z = UnityEngine.Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z);

            GameObject Ring = LeanPool.Spawn(Prefab, Position, Quaternion.identity);
            LeanPool.Despawn(Ring, MaxRingLifetime);

            yield return new WaitForSeconds(UnityEngine.Random.Range(MinSpawnDelay, MaxSpawnDelay));
        }   
    }
}
