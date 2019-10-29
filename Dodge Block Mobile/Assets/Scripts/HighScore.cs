using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text highScoreText;
    private string highScoreString;
    private float highscore;

    void Start()
    {
        highScoreText = highScoreText.GetComponent<Text>();
        highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString() + "s";
    }

    void Update () {
        highscore = PlayerPrefs.GetFloat("HighScore");
        highScoreString = highscore.ToString();
        highScoreString = highScoreString.Substring(0, highScoreString.Length) + "s";
        highScoreText.text = highScoreString;
	}
}
