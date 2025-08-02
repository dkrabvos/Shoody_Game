using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundPlayer : MonoBehaviour
{
    public Transform player;
    public float orbitRadius = 2f;
    public float orbitSpeed = 50f;
    private float angle;

    void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.Find("Player");
            if (p != null)
                player = p.transform;
        }

        if (player != null)
        {
            Vector3 startPos = player.position + new Vector3(orbitRadius, 0f, 0f);
            transform.position = startPos;
        }
    }

    void Update()
    {
        if (player == null) return;

        // 각도 증가
        angle += orbitSpeed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * orbitRadius;
        transform.position = player.position + offset;
    }
}
