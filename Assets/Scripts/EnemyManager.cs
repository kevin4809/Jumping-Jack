using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Numero de enemigos que puedes aparecer en las posiciones Y y X
    public int numEnemysInX;
    public int numEnemysInY; 

    //Prefabs de los enemigos
    public GameObject EnemyOne;
    public GameObject EnemyTwo;
    public GameObject EnemyTree;

    //Aqui se almazenara las posicones en las cuales podran aparecer los enemigos 
    private float PositionX;
    private float PositionY;

    //Variable la cual se encargara de escoger que enemigo se instanciara 
    public int selectEnemy;

    private void Awake()
    {
        //Llama el metodo en el cual sera modificado el numero de enemigos que pueden aparecer 
        ChangeValues();
    }
    void Start()
    {
        //Se instancia el numero de enemigos 
        for (int x = 0; x < numEnemysInX; x++)
        {
            PositionY = -2.645f;
            for (int y = 0; y < numEnemysInY; y++) 
            {
                //Se da un valor aleatorio para escoger un enemigo alazar y para definir su posicion 
                selectEnemy = Random.Range(0, 3);
                PositionX = Random.Range(-6.34f, 6.34f);

                if (selectEnemy == 0)
                {
                    //Se instancia el primer tipo de enemigo 
                    GameObject go = GameObject.Instantiate(EnemyOne) as GameObject; 

                    //Se da la posicion en la cual sera instanciado el enemigo 
                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }

                if (selectEnemy == 1)
                {
                    //Se instancia el segundo tipo de enemigo 
                    GameObject go = GameObject.Instantiate(EnemyTwo) as GameObject;

                    //Se da la posicion en la cual sera instanciado el enemigo 
                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }

                if (selectEnemy == 2)
                {
                    //Se instancia el tercer tipo de enemigo 
                    GameObject go = GameObject.Instantiate(EnemyTree) as GameObject;

                    //Se da la posicion en la cual sera instanciado el enemigo 
                    Vector3 position = new Vector3(PositionX, PositionY, 0F);
                    PositionY += 1.2f;
                    go.transform.position = position;
                }





            }
        }
            
    }



    //Metodo en el cual definimos el numero de enemigos que aparezeran dependiendo del nivel en el que se encuentre el jugador
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