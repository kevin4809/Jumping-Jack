using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePlataforms : MonoBehaviour
{
    public int width;  //Definimos el numero de prefabs que queremos instanciar, en forma horizontal 
    public int height; //Definimos el numero de prefabs que queremos instanciar, en forma vertical 

    public GameObject numPLatafOne; //El Gameobject que deseamos Instanciar 
    private GameObject[,] grid; //Aqui almazenaremos los Gameobjects instanciados 
    public GameObject numPlatafTwo;

    private float[] valueX = new float[] { -20.5f, -16.5f, -12.5f };
    private float[] valueY = new float[] { -3f, -1f, 1f, 3f, 5f };

    public static int randomDirection;
   private int randomPlataform;
    public float vX;
    public float vY;
    void Start()
    {

        grid = new GameObject[width, height];
        for (int x = 0; x < width; x++) //x es es igual a 0. Si x es menor que width se entrara adentro del for, y el valor de x aumentara  
        {
            vY = -3f;
            for (int y = 0; y < height; y++) //y es es igual a 0. Si y es menor que height se entrara adentro del for, y el valor de y aumentara  
            {

                randomPlataform = Random.Range(0, 2);
                randomDirection = Random.Range(0, 2);
                if (randomPlataform == 0)
                {

                    GameObject go = GameObject.Instantiate(numPLatafOne) as GameObject; //Se instancia el gameobject 

                    if (randomDirection == 0)
                    {
                        vX = Random.Range(-11.64f, -3f);
                        Vector3 position = new Vector3(vX, vY, 0F);
                        vY += 1.2f;
                        go.transform.position = position;
                    }
                    else
                    {
                        vX = Random.Range(-27.22f, -35f);
                        Vector3 position = new Vector3(vX, vY, 0F);
                        vY += 1.2f;
                        go.transform.position = position;
                    }

                }
                else
                {
                    GameObject go = GameObject.Instantiate(numPlatafTwo) as GameObject; //Se instancia el gameobject

                    Vector3 position = new Vector3(4f, vY, 0f);
                    vY += 1.2f;
                    go.transform.position = position;

                }



            }



            //Asignamos la posicion el la cual se van a instanciar los Gameobjects 
            // float spawnYPosition = Random.Range(plataformMin, plataformMax);



            //  grid[x, y] = go;  //se almacena la posicion de los Gameobjects en "x" y "y"


        }

    }
}

