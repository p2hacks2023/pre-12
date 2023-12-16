using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIdirector : MonoBehaviour
{
    GameObject Gauge;  
    GameObject Button;

    public int GraveLevel = 1;
    public float GaugeValue = 0;
    public bool ifWaterMode = false;


    // Start is called before the first frame update
    void Start()
    {
        this.Gauge = GameObject.Find("Gauge");
        this.Button = GameObject.Find("Button");
    }

    // Update is called once per frame
    void Update()
    {
        if (ifWaterMode)
        {
            Button.GetComponent<Image>().color = new Color(1f,0.8f,1f);
        }
        else
        {
            Button.GetComponent<Image>().color = Color.white;
        }


        ChangeLevel();

    }

    // when a grave is watered
    void IncreaseGauge()
    {
        this.Gauge.GetComponent<Image>().fillAmount +=0.1f;
    }

    public void WaterButtonPressed()
    {
        if (ifWaterMode)
        {
            ifWaterMode = false;

        }
        else
        {
            ifWaterMode = true;
        }
    }

    public void CountWaterTime()
    {
        GaugeValue += 0.1f;
        IncreaseGauge();
    }

    void ChangeLevel()
    {
        if (GaugeValue >= 1f)
        {
            GaugeValue = 0;
            GraveLevel += 1;
            this.Gauge.GetComponent<Image>().fillAmount -= 1f;
        }
    }


    
}
