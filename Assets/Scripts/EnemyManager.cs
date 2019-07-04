using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int width;  //Definimos el numero de prefabs que queremos instanciar, en forma horizontal 
    public int height; //Definimos el numero de prefabs que queremos instanciar, en forma vertical 


    private GameObject[,] grid; //Aqui almazenaremos los Gameobjects instanciados 

    public GameObject EnemyOne;
    public GameObject EnemyTwo;
    public GameObject EnemyTree;

    private float PositionX;
    private float PositionY;

    public int selectEnemy;

    void Start()
    {

        grid = new GameObject[width, height];
       
            PositionY = -2.645f;
            for (int y = 0; y < height; y++) //y es es igual a 0. Si y es menor que height se entrara adentro del for, y el valor de y aumentara  
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

                if(selectEnemy == 1)
                {
                    GameObject go = GameObject.Instantiate(EnemyTwo) as GameObject; //Se instancia el gameobject 



                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }

                if(selectEnemy == 2)
                {
                    GameObject go = GameObject.Instantiate(EnemyTree) as GameObject; //Se instancia el gameobject 



                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }
               




            }
        }
}