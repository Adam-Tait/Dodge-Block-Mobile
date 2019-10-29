using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text timerText;
    private float timer;
    private string timeString;

	// Use this for initialization
	void Start () {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer = Time.timeSinceLevelLoad;
        timeString = timer.ToString();
        if (timer < 10f)
        {
            timeString = timeString.Substring(0, 5) + "s";
        }
        else if (timer >= 100f)
        {
            timeString = timeString.Substring(0, 7) + "s";
        }
        else if (timer >= 10f)
        {
            timeString = timeString.Substring(0, 6) + "s";
        }
        timerText.text = timeString;
	}
}
