﻿using UnityEngine;
using System.Collections;

public class ActivateGameOver : MonoBehaviour {

    public GameObject cameraGame;
    public GameObject cameraGameOver;
    public GameObject sceneGame;
    public GameObject sceneGameOver;

    public AudioClip gameOverClip;

    public TextMesh highscoreGameOverScreen;
    public TextMesh highscoreGameScreen;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "GameOver");	
	}

    void GameOver(Notification notificacion)
    {
        /*GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = gameOverClip;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();*/
        cameraGameOver.SetActive(true);
        cameraGame.SetActive(false);

        if (sceneGame)
        {
            sceneGame.SetActive(false);
        }
        sceneGameOver.SetActive(true);

        //Debug.Log("metemos game over" );
        //Debug.Log(highscoreGameScreen.text);
        ManageRecords();
    }

    void ManageRecords()
    {
        int currentRecord = int.Parse(highscoreGameScreen.text);

        int savedRecord = GetScore();

        if (currentRecord > savedRecord)
        {
            SetScore(currentRecord);
            highscoreGameOverScreen.text = currentRecord.ToString();
        } else
        {
            highscoreGameOverScreen.text = savedRecord.ToString();
        }
    }

    public int GetScore()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        return PlayerPrefs.GetInt("Score");
    }

    public void SetScore(int value)
    {
        PlayerPrefs.SetInt("Score", value);
    }

    void Update()
    {

    }
}
