using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public float pipeSpeed = -10f;

    public Vector3 v_move = Vector3.zero;

    public void MovingPipe()
    {
        v_move = this.transform.position;
        v_move.x += pipeSpeed * Time.deltaTime;
        if (v_move.x < -200)
        {
            this.gameObject.SetActive(false);
        }
        this.transform.position = v_move;
    }

    public void ResetPipe()
    {
        v_move.x = top.position.x;
        v_move.y = Random.Range(bottom.position.y, top.position.y);
        this.transform.position = v_move;
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void Update()
    {
        if (GameProperties.IsAlive)
            MovingPipe();
    }
}
