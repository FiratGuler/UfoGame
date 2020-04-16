using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController ornek;

    private const string High_score = "High Score";
    // Start is called before the first frame update
    void Awake()
    {
        TekilNesne();
        OyunIlk();
    }



    void TekilNesne()
    {
        if (ornek != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OyunIlk()
    {
        if (PlayerPrefs.HasKey("OyunIlk"))
        {
            PlayerPrefs.SetInt(High_score, 0);
            PlayerPrefs.SetInt("OyunIlk", 0);
        }
    }
    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt(High_score, score);
    }
    public int getHighScore()
    {
        return PlayerPrefs.GetInt(High_score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
