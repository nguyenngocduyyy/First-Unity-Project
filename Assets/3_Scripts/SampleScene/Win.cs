using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text Score;
    public int GameScore = 0;
    //public GameObject Instance;
    public static Action<int> UpdateWinScore;
    // Start is called before the first frame update
    void Start()
    {
        //Instance.SetActive(false);
        UpdateWinScore -= SetWinScore;
        UpdateWinScore += SetWinScore;
    }

    public void SetWinScore(int score)
    {
        GameScore = score;
    }

    void OnEnable()
    {
        Score.text = ("Your score: " + GameScore.ToString());
    }
}
