using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    private int score;

    private bool gameOver;
    public bool isDead;

    void Awake()
    {
        instance = this;

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!gameOver && isDead)
        {
            gameOver = true;
            StartCoroutine(GameOver());
        }    
    }

    public void IncreseScore()
    {
        score++;
        scoreText.text = score.ToString("00");
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}
