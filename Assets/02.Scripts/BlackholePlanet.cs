using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholePlanet : MonoBehaviour
{
    [Header("Blackhole Settings")]
    public float pullRange = 5f;           // ���� �ݰ�
    public float pullStrength = 5f;        // ������� �� ����
    public float pullDelay = 0.02f;        // ���� �ֱ� (ª�� �Ҽ��� �ڿ�������)

    private float timer = 0f;

    public bool isInBlackhole = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= pullDelay)
        {
            PullMeteorites();
            timer = 0f;
        }
    }
    public void PullMeteorites()
    {
        // ���� ���� ���� �ݶ��̴� ��������
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pullRange);

        foreach (Collider2D hit in hits)
        {
            // Meteorite �±� �Ǵ� Ư�� ������Ʈ�� ���͸�
            if (hit.CompareTag("Meteo"))
            {
                isInBlackhole = true;
                Rigidbody2D rb = hit.attachedRigidbody;
                if (rb != null)
                {
                    // ��Ȧ�� ���� ���� ����
                    Vector2 directionToCenter = ((Vector2)transform.position - rb.position).normalized;

                    // �Ÿ� ��� ���� (�ɼ�)
                    float distance = Vector2.Distance(transform.position, rb.position);
                    float force = pullStrength * (1f - (distance / pullRange)); // �������� ���ϰ�

                    // �������
                    rb.AddForce(directionToCenter * force, ForceMode2D.Force);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 0f, 0f, 0.4f);
        Gizmos.DrawSphere(transform.position, pullRange);
    }
}
