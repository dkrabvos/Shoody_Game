using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public int gauge = 0;                // 현재 게이지
    public int gaugePerMeteorite = 10;   // 운석 하나당 증가량

    public TextMeshProUGUI gaugeText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGaugeText();
    }

    public void AddGauge()
    {
        gauge += gaugePerMeteorite;
        UpdateGaugeText();
    }

    private void UpdateGaugeText()
    {
        if (gaugeText != null)
        {
            gaugeText.text = $"Gauge: {gauge}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
