using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlaySFX : MonoBehaviour
{
    public SFX_Name clipName;
    public void PlaySFX()
    {
        SoundManager.Instance.PlaySFX(clipName);
    }
}
