using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public static int score;

    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        //score = 0;

        score = PlayerPrefs.GetInt("PlayerScore");
    }

    private void Update()
    {
        if (score < 0)
        {
            score = 0;
            Debug.Log("The score tried going below zero");
        }

        text.text = "" + score; 
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PlayerPrefs.SetInt("PlayerScore", score);
    }

    public static void Reset()
    {
        score = 0;
        PlayerPrefs.SetInt("PlayerScore", score);
    }

}
