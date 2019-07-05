using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{  
    //Variable estatica con la cual se aplicara singleton
    public static LevelManager instance;

    //Variable que sera igual al nivel en el que este el jugador 
    public  int level;
    public Text LevelText = null;
    private void Awake()
    {
        //Singleton
        if(instance == null)
        {
            instance = this;
        }
        else { if(instance != this)
            {

                Destroy(gameObject);
            }
        }   
    }

    private void Start()
    {
        //Se guarda el nivel en el cual se encuentra el jugador  
        if (PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.GetInt("Level", level);
            level = 1;
            LevelManager.instance.level = PlayerPrefs.GetInt("Level");
        }

        //Busca un gameobject que se llama "levelText" en la scena 
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    public void checkForNextLevel()
    {
        levelUp();
    }

    //Metodo en el cual se aumentara el nievel  se guardaran los datos y se recargara la scena 
    public void levelUp()
    {
        level += 1;
        Save();
        SceneManager.LoadScene("1");
       
    }

    //Metodo en el cual se guardara la informacion de las vidas, nivel y puntaje Con playerprefbs
     public void Save()
    {
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Live", MoveCharapter.live);
        PlayerPrefs.SetInt("Score", Score.score);
      
    }

    private void Update()
    {
        // Se actualiza constantemente el texto de level en la scena 
        LevelText.text = "Level:  " + level;
    }


}