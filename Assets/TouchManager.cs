using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchManager : MonoBehaviour
{
    public float laserLength = 0.3f;
    [HideInInspector]
    public int Score = 0;
    public TMP_Text Score_txt;
    public TMP_Text Gameover_H_Score_txt;
    int HighScore = 0;
    public GameObject Gameover;

    public AudioSource audio;
    public AudioClip GameoverClip, Pop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D Ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up * laserLength);
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up * laserLength, Color.red);

            if (Ray.collider != null)
            { 
                if(Ray.collider.gameObject.CompareTag("Balloon"))
                {
                    audio.clip = Pop;
                    audio.Play();
                    Score++;
                    Score_txt.text = "Score : " + Score;

                    Ray.collider.gameObject.GetComponent<Animator>().SetBool("Destroy", true);
                    Destroy(Ray.collider.gameObject, 0.4f);
                }

                if (Ray.collider.gameObject.CompareTag("Enemy"))
                {
                    audio.clip = GameoverClip;
                    audio.Play();
                    CalculateHighScore(Score);
                    Gameover.SetActive(true);
                    Time.timeScale = 0;
                    Ray.collider.gameObject.GetComponent<Animator>().SetBool("Destroy", true);
                    Destroy(Ray.collider.gameObject, 0.4f);
                }
            }
        }
    }

    public void CalculateHighScore(int scr)
    {
        HighScore = PlayerPrefs.GetInt("HScore", 0);
        if (scr > HighScore)
        {
            HighScore = scr;
            PlayerPrefs.SetInt("HScore", HighScore);
        }
        Gameover_H_Score_txt.text = "HighScore :" + PlayerPrefs.GetInt("HScore", 0);
    }
}
