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
    public GameObject audioScreenObject;
    public GameObject audioSettings;
    public GameObject goBack;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    
    public void StartGame()
    {
        Time.timeScale = 1;
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
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

    public void ShowAudioSettings()
    {
        audioScreenObject.SetActive(true);
        goBack.SetActive(true);
        audioSettings.SetActive(false);
        PauseGame();
    }

    public void HideAudioSettings()
    {
        audioScreenObject.SetActive(false);
        goBack.SetActive(false);
        audioSettings.SetActive(true);
        ResumeGame();
    }
}
