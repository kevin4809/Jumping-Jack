using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public  int level;
    public Text LevelText = null;


    private void Awake()
    {

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
        if (PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.GetInt("Level", level);
            level = 1;
            LevelManager.instance.level = PlayerPrefs.GetInt("Level");
        }

        LevelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    public void checkForNextLevel()
    {
        levelUp();
    }

    public void levelUp()
    {
        level += 1;
        SceneManager.LoadScene("1");
        Save();
    }

     public void Save()
    {
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Live", MoveCharapter.live);
        PlayerPrefs.SetInt("Score", Score.score);
      
    }

    private void Update()
    {
        LevelText.text = "Level:  " + level;
    }


}