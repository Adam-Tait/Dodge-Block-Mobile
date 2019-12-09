using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float slowness = 10f;

    public GameObject panel;
    public GameObject lPause;
    public GameObject rPause;
    public GameObject RHPanel;
    public GameObject LHPanel;

    public int LHMode = 0;

    public Toggle toggle;
    
    public void SaveScore(float currentscore, float highscore)
    {   
        if (currentscore >= highscore)
        {
            PlayerPrefs.SetFloat("HighScore", currentscore);
        }
    }

    void Awake()
    {
        LHMode = PlayerPrefs.GetInt("LHMode");
        if (RHPanel.activeSelf && LHMode == 1)
        {
            RHPanel.SetActive(false);
            LHPanel.SetActive(true);
            PlayerPrefs.SetInt("LHMode", 1);
            toggle.isOn = true;
        }
    }

    public void ToggleHand()
    {
        if (toggle.isOn)
        {
            RHPanel.SetActive(false);
            LHPanel.SetActive(true);
            PlayerPrefs.SetInt("LHMode", 1);
        }
        else if (!toggle.isOn)
        {
            LHPanel.SetActive(false);
            RHPanel.SetActive(true);
            PlayerPrefs.SetInt("LHMode", 0);
        }
        else
        {
            LHPanel.SetActive(false);
            RHPanel.SetActive(true);
            PlayerPrefs.SetInt("LHMode", 0);
        }
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);

            /*if (LHMode == 0)
                toggle.isOn = false;
            else if (LHMode == 1)
                toggle.isOn = true;*/

            lPause.SetActive(false);
            rPause.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            lPause.SetActive(true);
            rPause.SetActive(true);
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