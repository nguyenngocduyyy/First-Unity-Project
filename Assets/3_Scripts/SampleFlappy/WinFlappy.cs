using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinFlappy : MonoBehaviour
{
    public Text finalScore;
    public Text highScore;
    void OnEnable()
    {
        finalScore.text = GameProperties.Score.ToString();
        highScore.text = "High Score: " + PlayerPrefs.GetInt(SaveKey.HI_SCORE, 0).ToString();
    }

}