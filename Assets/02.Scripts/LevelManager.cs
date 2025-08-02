using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("UI 연결")]
    public TextMeshProUGUI gaugeText;
    public TextMeshProUGUI levelText;

    [Header("게이지 및 레벨 설정")]
    public int gaugeToLevelUp = 30;
    public int currentLevel = 1;

    public GameObject guage;
    Gauge ex;


    void Start()
    {
        ex = guage.GetComponent<Gauge>();
        UpdateUI();
    }

    
    public void Update()
    {
        if (ex.gauge >= gaugeToLevelUp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Debug.Log("레벨업 조건 충족");
        ex.gauge -= gaugeToLevelUp;
        currentLevel++;

        UpdateUI();
    }


    void UpdateUI()
    {
        if (gaugeText != null)
            gaugeText.text = "Gauge: " + ex.gauge + " / " + gaugeToLevelUp;

        if (levelText != null)
            levelText.text = "Level: " + currentLevel;
    }

}
