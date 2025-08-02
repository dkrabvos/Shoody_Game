using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public GameObject meteoritePrefab;
    public float spawnInterval = 1.5f;
    public float spawnRadius = 10f; // 화면 밖 원형 경계
    public Vector2 moveSpeedRange = new Vector2(1f, 4f);

    void Start()
    {
        InvokeRepeating("SpawnMeteorite", 1f, spawnInterval);
    }

    void SpawnMeteorite()
    {
        // 랜덤한 원형 바깥 위치 계산
        Vector2 spawnPos = Random.onUnitSphere * spawnRadius;

        // Z축 제거 (2D니까)
        spawnPos = new Vector2(spawnPos.x, spawnPos.y);

        // 메테오 생성
        GameObject meteor = Instantiate(meteoritePrefab, spawnPos, Quaternion.identity);

        // GravityToCenter 스크립트에 속도 랜덤 설정
        GravityToCenter gravity = meteor.GetComponent<GravityToCenter>();
        if (gravity != null)
        {
            gravity.moveSpeed = Random.Range(moveSpeedRange.x, moveSpeedRange.y);
        }
    }
}
