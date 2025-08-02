using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantMeteoriteSpawner : MonoBehaviour
{
    public GameObject giantMeteoritePrefab;
    public float spawnDistanceFromCenter = 7f;

    void Start()
    {
        SpawnGiantMeteoriteOnce();
    }

    void SpawnGiantMeteoriteOnce()
    {
        Debug.Log("💥 거대 운석 생성 시도됨");

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = randomDirection * spawnDistanceFromCenter;

        Instantiate(giantMeteoritePrefab, spawnPos, Quaternion.identity);
    }
}

