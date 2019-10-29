using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float slowness = 10f;

    public GameObject panel;
    public GameObject pause;
    
    public void SaveScore(float currentscore, float highscore)
    {   
        if (currentscore >= highscore)
        {
            PlayerPrefs.SetFloat("HighScore", currentscore);
        }
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            pause.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            pause.SetActive(true);
        }
        // PlayerPrefs.SetFloat("HighScore", 0f);
        // Only way to reset high score that I set
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f / slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}