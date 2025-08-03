using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSkill : MonoBehaviour
{
    public List<GameObject> skills = new List<GameObject>(6); // ��ü 6�� ��ų ������Ʈ
    public Dictionary<GameObject, int> currentSkills = new Dictionary<GameObject, int>(); // ���õ� ��ų�� �� ����

    public UIManager manager;

    private void Start()
    {
        /*
        for (int i = 1; i <= 6; i++)
        {
            skills.Add(transform.GetChild(i).gameObject);
        }
        */

        SelectSkill();
    }

    public void SelectSkill()
    {
        List<GameObject>selectable = new List<GameObject>();

        if (currentSkills.Count < 3)
        {
            // ���� 3�� ���϶�� ��ü skills �� currentSkills�� ���� �� �߿����� �����ϰ� 3�� ����
            List<GameObject> available = new List<GameObject>(skills);
            available.RemoveAll(skill => currentSkills.ContainsKey(skill));

            int count = Mathf.Min(3, available.Count);
            while (selectable.Count < count)
            {
                Debug.Log("selection count: " + selectable.Count);
                int rand_index = Random.Range(0, available.Count);

                GameObject randSkill = available[rand_index];
                manager.Selection(rand_index, selectable.Count);
                if (!selectable.Contains(randSkill))
                    selectable.Add(randSkill);
                
            }
        }
        else
        {
            // �̹� 3�� �� ���������� currentSkills �ȿ��� ���� 3�� ����
            List<GameObject> keys = new List<GameObject>(currentSkills.Keys);
            int count = Mathf.Min(3, keys.Count);
            while (selectable.Count < count)
            {
                GameObject randSkill = keys[Random.Range(0, keys.Count)];
                if (!selectable.Contains(randSkill))
                    selectable.Add(randSkill);
            }
        }

        
        
    }

    public void SetSkill(GameObject skill)
    {

        int level = 1;

        if (currentSkills.ContainsKey(skill))
        {
            currentSkills[skill]++;
            level = currentSkills[skill];
        }
        else
        {
            currentSkills.Add(skill, level);
            currentSkills[skill] = 1;
            skill.SetActive(true); // 1������ �� ó�� ����
        }

        // �ɷ�ġ ���� ó��
        int damage = 0;
        int speed = 0;

        if (level == 1)
        {
            // ù �����̶� ������Ʈ�� Ȱ��ȭ
        }
        else if (level <= 4)
        {
            damage = 2;
            speed = 10;
        }
        else if (level <= 8)
        {
            damage = 5;
            speed = 20;
        }
        else
        {
            damage = 8;
            speed = 30;
        }

        // ��ų�� ���� ���� ���� (��: ������Ʈ �����ؼ� ����)
        Debug.Log($"[��ų: {skill.name}] ���� {level} -> ������ +{damage}, �ӵ� +{speed}");
        Debug.Log("���� ������ ��ų: " + currentSkills);

        // ����: skill.GetComponent<YourSkillScript>().ApplyBuff(damage, speed);
    }
}
