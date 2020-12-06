using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Point_And_Time_Manager : MonoBehaviour
{
    public GameObject pointsText;
    public GameObject timerText;
    public GameObject highScoreText;
    float limitSeconds;
    float step = 1f;
    int startOrNah;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.GetComponent<Text>().text = "Points: 0";
        limitSeconds = 31f;
        timerText.GetComponent<Text>().text = "Time Left: 30.0";
        highScoreText.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Count_Down.beginGame == true)
        {
            pointsText.GetComponent<Text>().text = "Points: " + Player.points;
            if (startOrNah == 0)
            {
                StartCoroutine(TimerRoutine());
                startOrNah++;
            }
        }
    }

    IEnumerator TimerRoutine()
    {
        while (limitSeconds > 0)
        {
            limitSeconds -= step;
            timerText.GetComponent<Text>().text = "Time Left: " + limitSeconds.ToString("n1");
            if(limitSeconds == 0 && Player.gameWon == false)
            {
                Player.gameLost = true;
                SceneManager.LoadScene("YOU_WON");
                Count_Down.beginGame = false;
            }
            if (Player.points > PlayerPrefs.GetFloat("HighScore", 0f))
            {
                PlayerPrefs.SetFloat("HighScore", Player.points);
                highScoreText.GetComponent<Text>().text = "Best: " + Player.points.ToString();
            }
            yield return new WaitForSeconds(step);
        }
    }
}
