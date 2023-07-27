using System.Collections;
using UnityEngine;
using UniRx;
using System;
using Lean.Pool;

public class Spawner : MonoBehaviour
{
    private bool isSpawningPaused = false;
    private Collider SpawnArea;
    private IDisposable SpawnDisposable;

    [SerializeField]
    private GameObject[] RingPrefabs;

    [Header("Spawn Settings")]
    [SerializeField]
    private float MinSpawnDelay = 0.25f;

    [SerializeField]
    private float MaxSpawnDelay = 1f;
    private float totalDropChances = 0f;

    private void Awake()
    {
        SpawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        SpawnDisposable = Observable.FromCoroutine(Spawn).Subscribe().AddTo(this);
        // Calculate the total drop chances when the spawner is enabled
        CalculateTotalDropChances();
    }

    private void CalculateTotalDropChances()
    {
        totalDropChances = 0f;

        // Iterate over all the ring prefabs and get their dropChance from the RingBase
        foreach (GameObject prefab in RingPrefabs)
        {
            RingBase ring = prefab.GetComponent<RingBase>();
            if (ring != null)
            {
                totalDropChances += ring.dropChance;
            }
        }

        // If the totalDropChances exceed 1, scale down the individual drop chances
        if (totalDropChances > 1f)
        {
            foreach (GameObject prefab in RingPrefabs)
            {
                RingBase ring = prefab.GetComponent<RingBase>();
                if (ring != null)
                {
                    ring.dropChance /= totalDropChances;
                }
            }
            totalDropChances = 1f;
        }
    }

    private void OnDisable()
    {
        SpawnDisposable?.Dispose();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        while (enabled)
        {
            if (!isSpawningPaused)
            {
                // Generate a random value between 0 and totalDropChances
                float randomValue = UnityEngine.Random.Range(0f, totalDropChances);

                GameObject Prefab = null;

                // Choose the prefab based on their dropChance
                foreach (GameObject prefab in RingPrefabs)
                {
                    RingBase ring = prefab.GetComponent<RingBase>();
                    if (ring != null)
                    {
                        if (randomValue < ring.dropChance)
                        {
                            Prefab = prefab;
                            break;
                        }
                        else
                        {
                            randomValue -= ring.dropChance;
                        }
                    }
                }
                Vector3 Position = new Vector3();
                Position.x = UnityEngine.Random.Range(
                    SpawnArea.bounds.min.x,
                    SpawnArea.bounds.max.x
                );
                Position.y = UnityEngine.Random.Range(
                    SpawnArea.bounds.min.y,
                    SpawnArea.bounds.max.y
                );
                Position.z = UnityEngine.Random.Range(
                    SpawnArea.bounds.min.z,
                    SpawnArea.bounds.max.z
                );
                GameObject Ring = LeanPool.Spawn(Prefab, Position, Quaternion.identity);
                // LeanPool.Despawn(Ring, MaxRingLifetime);
            }
            yield return new WaitForSeconds(UnityEngine.Random.Range(MinSpawnDelay, MaxSpawnDelay));
        }
    }

    public void PauseSpawning()
    {
        Time.timeScale = 0f;
        isSpawningPaused = true;
    }

    public void ResumeSpawning()
    {
        Time.timeScale = 1f;
        isSpawningPaused = false;
    }

    public void EndSpawning()
    {
        isSpawningPaused = true;
    }
}
