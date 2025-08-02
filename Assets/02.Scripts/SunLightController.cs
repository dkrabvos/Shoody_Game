using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightController : MonoBehaviour
{
    [SerializeField] private Transform targetOrigin; // 회전 기준 위치 (예: 화면 중심)


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main == null) return;

        if (Input.GetMouseButtonDown(0)) // 0: 좌클릭, 1: 우클릭, 2: 휠클릭
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("누른 상태");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

  

            // 마우스 위치를 월드 좌표로 변환
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        // 회전 기준 위치 설정 (기본: 오브젝트 자신의 위치)
        Vector3 origin = targetOrigin ? targetOrigin.position : transform.position;

        // 방향 벡터 계산
        Vector3 dir = (mouseWorld - origin).normalized;

        // 회전 각도 계산
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Z축 기준 회전 적용 (2D)
        transform.rotation = Quaternion.Euler(0, 0, angle+90f);

    }
}
