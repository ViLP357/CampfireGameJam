using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    // Start is called before the first frame update
    public static Scores instanssi;
    public TMP_Text[] nimet;
    public TMP_Text[] pisteet;
    public TMP_Text currentScore;
    public TMP_InputField pelaajanimi;

    int highScore = 100000;
    String highScoreName = "----";
    public int score = 0;
    //List<string> names = new List<string>();
    //List<string> scores = new List<string>();
    void Start()
    {
        //PlayerPrefs.deleteAll();
        instanssi = this;
        //pelaajanimi.text = "";
        haePisteet();
        currentScore.text = GameController.instanssi.muunnaTekstiksi(PlayerPrefs.GetInt("LatestScore"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void asetaPisteet() 
    {
        Debug.Log("asetus");
        score = PlayerPrefs.GetInt("LatestScore");
        Debug.Log(score + " " + highScore);
        if ((score > 0 )&&( highScore == 0|| score < highScore )&& pelaajanimi.text != "")
        {
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.SetString("HighscoreName", pelaajanimi.text);
            pelaajanimi.text ="";
        } else
        {
            Debug.Log("ei aseteta");
        }
        haePisteet();
    }
    public void haePisteet()
    {
        Debug.Log("Haku");
        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreName = PlayerPrefs.GetString("HighscoreName");
        if (highScoreName.Length > 0)
        {
            nimet[0].text = highScoreName;
        } else
        {
            nimet[0].text = "----";
        }
        
        pisteet[0].text = GameController.instanssi.muunnaTekstiksi(highScore);

        //for (int i = 0; i<5;i++)
        //{
        //    scores.Add(PlayerPrefs.GetString("score" + i.ToString()));
        //}
        
    }
}
