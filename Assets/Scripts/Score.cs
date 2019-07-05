using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Variables con las cuales manejaremos el puntaje del jugador 
    public Text scoreText = null;
    public static int score = 0;


    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
   
        //Se optiene el puntaje guardado en el playerprefbs
        if (PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.GetInt("Score", score);
        }  
    }

    void Update()
    {
        //Se actualiza constantemente el puntaje en la scena 
        scoreText.text = "Score:  " + score;
      
    }
}
