using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravity = -10;
    public float max_gravity = -10;
    public Vector3 v_gravity = Vector3.zero;
    public void OnEnable()
    {
        GameProperties.IsGrounded = true;
        // v_gravity = Vector3.zero;
        Invoke("Startgravity", 0f);
    }

    public void Startgravity()
    {
        GameProperties.IsGrounded = false;
    }

    public void Update()
    {
        if (!GameProperties.IsGrounded && Time.timeScale > 0)
        {
            if (v_gravity.y > max_gravity)
                v_gravity.y += gravity * Time.deltaTime;

            this.transform.position += v_gravity;
        }
    }
}
