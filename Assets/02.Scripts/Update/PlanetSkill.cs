using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSkill : MonoBehaviour
{
    public List<GameObject> skills = new List<GameObject>(); // 전체 6개 스킬 오브젝트
    public Dictionary<GameObject, int> currentSkills = new Dictionary<GameObject, int>(); // 선택된 스킬과 그 레벨

    public GameManager manager;

    private void Start()
    {
        for (int i = 1; i <= 6; i++)
        {
            skills.Add(transform.GetChild(i).gameObject);
        }
    }

    public void SelectSkill()
    {
        List<GameObject> selectable = new List<GameObject>();

        if (currentSkills.Count < 3)
        {
            // 아직 3개 이하라면 전체 skills 중 currentSkills에 없는 것 중에서만 랜덤하게 3개 선택
            List<GameObject> available = new List<GameObject>(skills);
            available.RemoveAll(skill => currentSkills.ContainsKey(skill));

            int count = Mathf.Min(3, available.Count);
            while (selectable.Count < count)
            {
                GameObject randSkill = available[Random.Range(0, available.Count)];
                if (!selectable.Contains(randSkill))
                    selectable.Add(randSkill);
            }
        }
        else
        {
            // 이미 3개 다 선택했으면 currentSkills 안에서 랜덤 3개 선택
            List<GameObject> keys = new List<GameObject>(currentSkills.Keys);
            int count = Mathf.Min(3, keys.Count);
            while (selectable.Count < count)
            {
                GameObject randSkill = keys[Random.Range(0, keys.Count)];
                if (!selectable.Contains(randSkill))
                    selectable.Add(randSkill);
            }
        }

        //이 부분은 나중에 UI 버튼 등에 연결
        foreach (var skill in selectable)
        {
            Debug.Log("선택 가능 스킬: " + skill.name);
        }

        // 예시용 수동 선택 처리 (실제 게임에서는 버튼 등으로 선택)
        SetSkill(selectable[0]); // 무조건 첫 번째 선택했다고 가정
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
            currentSkills[skill] = 1;
            skill.SetActive(true); // 1레벨일 때 처음 등장
        }

        // 능력치 증가 처리
        int damage = 0;
        int speed = 0;

        if (level == 1)
        {
            // 첫 등장이라 오브젝트만 활성화
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

        // 스킬에 따라 실제 적용 (예: 컴포넌트 접근해서 적용)
        Debug.Log($"[스킬: {skill.name}] 레벨 {level} -> 데미지 +{damage}, 속도 +{speed}");

        // 예시: skill.GetComponent<YourSkillScript>().ApplyBuff(damage, speed);
    }
}
