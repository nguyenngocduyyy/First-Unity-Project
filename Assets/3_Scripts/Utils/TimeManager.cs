using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public Action RealTimeTick;
    public Action TimeTick;

    void Awake()
    {
        Instance = this;
        InvokeRepeating("RealTiktak", 0, 1);
        StartCoroutine(Tiktak());
    }

    void RealTiktak()
    {
        if (RealTimeTick != null)
        {
            RealTimeTick();
        }
    }

    IEnumerator Tiktak()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (TimeTick != null)
            {
                TimeTick();
            }
        }
    }
}
