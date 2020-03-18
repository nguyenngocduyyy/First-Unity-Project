using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Fields
    public static SoundManager Instance;
    public AudioSource Music_Source;
    public AudioSource SFX_Source;
    public bool isMute = false;
    //Attribute
    [Range(0, 1)] public float MusicVolumn = 1;
    [Range(0, 1)] public float SFXVolumn = 1;
    public List<AudioClip> ListSFX;
    public List<AudioClip> ListMusic;
    #endregion Fields
    public void Awake()
    {
        isMute = PlayerPrefs.GetInt(SaveKey.MUTE, 0) > 0; // 0 = false, 1 = true
        MusicVolumn = PlayerPrefs.GetFloat(SaveKey.VOLUMN_MUSIC, 1.0f);
        SFXVolumn = PlayerPrefs.GetFloat(SaveKey.VOLUMN_SFX, 1.0f);
        Instance = this;

        SaveSoundSetting();

        Music_Source.mute = isMute;
        SFX_Source.mute = isMute;
        Music_Source.volume = MusicVolumn;
        //PlayMusic(0);
        //PlaySFX(SFX_Name.COIN);
    }

    void PlaySFX(int index)
    {
        SFX_Source.PlayOneShot(ListSFX[index], SFXVolumn);
    }
    public void PlaySFX(SFX_Name index)
    {
        PlaySFX((int)index);
    }

    public void PlaySFX(string clip_name)
    {
        for(int i = 0; i< ListSFX.Count; i++)
        {
            if(ListSFX[i].name == clip_name)
            {
                PlaySFX(i);
                return;
            }
        }
    }

    public void PlayMusic(int index)
    {
        Music_Source.clip = ListMusic[index];
        Music_Source.Play();
    }

    #region Helper Methods
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetInt(SaveKey.MUTE, isMute ? 1 : 0);
        PlayerPrefs.SetFloat(SaveKey.VOLUMN_MUSIC, MusicVolumn);
        PlayerPrefs.SetFloat(SaveKey.VOLUMN_SFX, SFXVolumn);
        PlayerPrefs.Save();
    }
    #endregion Helper Methods
}

public enum SFX_Name : int
{
    DIE         = 0,
    HIT         = 1,
    COIN        = 2,
    SWING       = 4
}
