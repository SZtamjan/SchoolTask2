using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    private int BS;
    public void BestScoreChecker()
    {
        
        BS = PlayerPrefs.GetInt("BestScore");
        if (GameManager.Instance.gameObject.GetComponent<GameManager>().points > BS) BestScoreUpdater();
    }

    private void BestScoreUpdater()
    {
        PlayerPrefs.SetInt("BestScore", GameManager.Instance.gameObject.GetComponent<GameManager>().points);
        Debug.Log("Max score to: " + GameManager.Instance.gameObject.GetComponent<GameManager>().points);
    }
}
