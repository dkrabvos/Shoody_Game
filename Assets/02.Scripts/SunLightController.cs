using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightController : MonoBehaviour
{
    [SerializeField] private Transform targetOrigin; // ȸ�� ���� ��ġ (��: ȭ�� �߽�)


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main == null) return;

        if (Input.GetMouseButtonDown(0)) // 0: ��Ŭ��, 1: ��Ŭ��, 2: ��Ŭ��
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("���� ����");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

  

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
        transform.rotation = Quaternion.Euler(0, 0, angle+90f);

    }
}
