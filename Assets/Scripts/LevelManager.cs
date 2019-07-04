using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int levelMultiplier = 2;
    public int level;

    private void Awake()
    {
        instance = this;
    }

    public void checkForNextLevel()
    {
        levelUp();
        ChangeAttributes();
    }

    public void levelUp()
    {
        level += 1;
        Score.score = Score.score * levelMultiplier;
        Debug.Log("PaseDeNivel");
    }

    public void ChangeAttributes()
    {

    }
}
