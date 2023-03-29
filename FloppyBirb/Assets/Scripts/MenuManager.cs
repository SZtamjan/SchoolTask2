using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject bestScore;
    public void Start()
    {
        int tmp = PlayerPrefs.GetInt("BestScore");
        bestScore.GetComponentInChildren<TextMeshProUGUI>().text = $"{tmp}";
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
