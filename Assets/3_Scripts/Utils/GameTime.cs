using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public Text Text_Time;
    public float realTimeCount = 0;
    public float timeCount = 0;
    void Start()
    {
        if(!Text_Time)
            Text_Time = this.GetComponent<Text>();

        realTimeCount = 0;
        timeCount = 0;

        TimeManager.Instance.RealTimeTick -= RealTimeTick;
        TimeManager.Instance.RealTimeTick += RealTimeTick;

        TimeManager.Instance.TimeTick -= TimeTick;
        TimeManager.Instance.TimeTick += TimeTick;
    }

    void RealTimeTick()
    {
        realTimeCount++;
        SetTimeText();
    }

    void TimeTick()
    {
        timeCount++;
        SetTimeText();
    }

    void SetTimeText()
    {
        Text_Time.text = realTimeCount + ":" + timeCount;
    }
}
