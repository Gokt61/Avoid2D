using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;

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

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}
