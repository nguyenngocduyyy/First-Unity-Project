using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTexture : MonoBehaviour
{
    public Material material;
    public float MoveSpeed = 0.5f;

    Vector2 tempOffset = Vector2.zero;
    Vector2 tempScale = Vector2.zero;
    public void RunBG()
    {
        tempOffset = material.mainTextureOffset;
        tempOffset.x += MoveSpeed * Time.deltaTime;
        if (tempOffset.x > 1)
            tempOffset.x--;
        material.mainTextureOffset = tempOffset;
    }

    public void Update()
    {
        if (GameProperties.IsAlive)
            RunBG();
    }
}
