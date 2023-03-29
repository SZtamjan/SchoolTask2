using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseUI;
    public GameObject audioObject;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    
    public void StartGame()
    {
        Time.timeScale = 1;
        audioObject.gameObject.GetComponent<SoundManager>().gameSong.Play();
    }

    private void ShowLoseUI()
    {
        loseUI.SetActive(true);
        UpdateBestScore();
        audioObject.gameObject.GetComponent<SoundManager>().gameSong.Stop();
        audioObject.gameObject.GetComponent<SoundManager>().hit.Play();

    }

    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        audioObject.gameObject.GetComponent<SoundManager>().gameSong.Play();
    }
    public void OnGameOver()
    {
        ShowLoseUI();
        Time.timeScale = 0;
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
    }

    public void UpdateBestScore()
    {
        int tmp = PlayerPrefs.GetInt("BestScore");
        loseUI.GetComponentInChildren<TextMeshProUGUI>().text = $"{tmp}";
    }
}
