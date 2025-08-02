using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightController : MonoBehaviour
{
    [SerializeField] private Transform targetOrigin; // ȸ�� ���� ��ġ (��: ȭ�� �߽�)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main == null) return;

        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        // ȸ�� ���� ��ġ ���� (�⺻: ������Ʈ �ڽ��� ��ġ)
        Vector3 origin = targetOrigin ? targetOrigin.position : transform.position;

        // ���� ���� ���
        Vector3 dir = (mouseWorld - origin).normalized;

        // ȸ�� ���� ���
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Z�� ���� ȸ�� ���� (2D)
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
