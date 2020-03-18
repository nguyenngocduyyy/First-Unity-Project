using System;
using UnityEngine;

public class GameProperties
{
    static bool isAlive = false;
    public static bool IsAlive //properties
    {
        get { return isAlive; }
        set
        {
            isAlive = value;
        }
    }

    static bool isGrounded = false;
    public static bool IsGrounded
    {
        get { return isGrounded; }
        set
        {
            isGrounded = value;
        }
    }

    static int score = 0;
    public static int Score
    {
        get { return score; }
        set
        {
            if (value >= 0)
            {
                score = value;
            }
        }
    }

}

public class SaveKey
{
    public const string HI_SCORE = "HiScore";
    public const string MUTE = "Mute";
    public const string VOLUMN_MUSIC = "Music Volumn";
    public const string VOLUMN_SFX = "SFX Volumn";
}