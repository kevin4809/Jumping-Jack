using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int numEnemysInX;
    public int numEnemysInY; 


    private GameObject[,] grid; //Aqui almazenaremos los Gameobjects instanciados 

    public GameObject EnemyOne;
    public GameObject EnemyTwo;
    public GameObject EnemyTree;

    private float PositionX;
    private float PositionY;

    public int selectEnemy;

    private void Awake()
    {
        ChangeValues();
    }
    void Start()
    {
       

        grid = new GameObject[numEnemysInX, numEnemysInY];
        for (int x = 0; x < numEnemysInX; x++)
        {
            PositionY = -2.645f;
            for (int y = 0; y < numEnemysInY; y++) //y es es igual a 0. Si y es menor que height se entrara adentro del for, y el valor de y aumentara  
            {

                selectEnemy = Random.Range(0, 3);
                PositionX = Random.Range(-6.34f, 6.34f);
                if (selectEnemy == 0)
                {
                    GameObject go = GameObject.Instantiate(EnemyOne) as GameObject; //Se instancia el gameobject 



                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }

                if (selectEnemy == 1)
                {
                    GameObject go = GameObject.Instantiate(EnemyTwo) as GameObject; //Se instancia el gameobject 



                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }

                if (selectEnemy == 2)
                {
                    GameObject go = GameObject.Instantiate(EnemyTree) as GameObject; //Se instancia el gameobject 



                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }





            }
        }
            
    }



    public void ChangeValues()
    {
        if (LevelManager.instance.level <= 1) { numEnemysInX = 0; numEnemysInY = 0; }
        if (LevelManager.instance.level == 2) { numEnemysInX = 1; numEnemysInY = 1; }
        if (LevelManager.instance.level == 3) { numEnemysInX = 1; numEnemysInY = Random.Range(1,4); }
        if (LevelManager.instance.level == 4) { numEnemysInX = Random.Range(1,2); numEnemysInY = Random.Range(1, 6); }
        if (LevelManager.instance.level == 5) { numEnemysInX = Random.Range(1, 3); numEnemysInY = Random.Range(3, 6); }
        if (LevelManager.instance.level >= 6) { numEnemysInX = Random.Range(1, 3); numEnemysInY = Random.Range(3, 8); }

    }
}