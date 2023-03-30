using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject bestScore;
    [SerializeField] private GameObject ui1;
    [SerializeField] private GameObject ui2;
    [SerializeField] private GameObject audioSettings;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject goBackButton;

    public void Start()
    {
        int tmp = PlayerPrefs.GetInt("BestScore");
        bestScore.GetComponentInChildren<TextMeshProUGUI>().text = $"{tmp}";
    }

    public void Button()
    {
        ui1.SetActive(false);
        ui2.SetActive(false);
        settingButton.SetActive(false);
        audioSettings.SetActive(true);
        goBackButton.SetActive(true);
    }

    public void GoBack()
    {
        ui1.SetActive(true);
        ui2.SetActive(true);
        settingButton.SetActive(true);
        audioSettings.SetActive(false);
        goBackButton.SetActive(false);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
