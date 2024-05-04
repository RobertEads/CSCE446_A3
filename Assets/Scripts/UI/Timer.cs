using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTime;
    public string preText;

    public TMP_Text timerText;
    public Image fill;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = preText + "" + (int)time + "s";
        fill.fillAmount = time / maxTime;

        if(time < 0)
        {
            time = 0;
            timerText.text = "";
        }
    }

    public void StartTimer(int duration)
    {
        maxTime = duration;
        time = maxTime;
    }

    public bool isCompleted()
    {
        return time <= 0;
    }
}
