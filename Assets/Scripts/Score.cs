using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText = null;
    public static float score = 0;


    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); 
    }

    void Update()
    {

        scoreText.text = "Score:  " + score;
      
    }


    public void AddScore(int newValue)
    {
        score += newValue;
    }
}
