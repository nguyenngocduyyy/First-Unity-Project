
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyJump : MonoBehaviour
{
    public GameObject gameplay;
    public GameObject gamewin;
    public CustomGravity C_Gravity;
    public float JumpForce = 50;
    Vector3 faceRotation = Vector3.zero;
    public Text scoreBox;
    public AudioSource audioSource;
    public AudioClip dieClip;
    public AudioClip scoreClip;
    public AudioClip wingClip;
    public Transform defaultPos;
    void OnEnable()
    {

        GameProperties.IsAlive = true;
        GameProperties.Score = 0;
        scoreBox.text = "0";
        // GameProperties.IsGrounded = false;
        this.gameObject.transform.position = defaultPos.position;
        Jump();
    }
    public void Jump()
    {
        //if(C_Gravity.v_gravity.y < 1)
        if (GameProperties.IsAlive)
        {
            C_Gravity.v_gravity.y = JumpForce;
            // audioSource.PlayOneShot(wingClip);
            SoundManager.Instance.PlaySFX(SFX_Name.SWING);

        }

    }

    public void Update()
    {
        faceRotation = C_Gravity.v_gravity + Vector3.right;
        faceRotation.y = Mathf.Clamp(faceRotation.y, -100, 1);
        this.transform.right = faceRotation;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Score"))
        {
            //TODO score
            Debug.Log("+1");

            // audioSource.PlayOneShot(scoreClip);
            SoundManager.Instance.PlaySFX(SFX_Name.COIN);
            GameProperties.Score++;
            scoreBox.text = GameProperties.Score.ToString();

        }
        else
        {
            if (GameProperties.IsAlive == true)
                // audioSource.PlayOneShot(dieClip);
                SoundManager.Instance.PlaySFX(SFX_Name.HIT);
            GameProperties.IsAlive = false;

            if (collider.CompareTag("Ground"))
            {
                GameProperties.IsGrounded = true;
                Invoke("GameOver", 1);
            }
        }
    }
    void GameOver()
    {
        if (GameProperties.Score > PlayerPrefs.GetInt(SaveKey.HI_SCORE, 0))
        {
            PlayerPrefs.SetInt(SaveKey.HI_SCORE, GameProperties.Score);
            PlayerPrefs.Save();
        }
        gameplay.SetActive(false);
        gamewin.SetActive(true);
        gamewin.GetComponent<Animator>().SetTrigger("Start");
    }

    public void TogglePauseResume()
    {
        if (Time.timeScale == 0)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
