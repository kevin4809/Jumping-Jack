using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePlataforms : MonoBehaviour
{
    //Variables las cuales definiran el numero de plataformas que apareceran en X y en Y 
    public int PLataformsInX;  
    public int PlataformsInY;

    //Prefabs de las dos posibles plataformas que pueden aparecer
    public GameObject numPLatafOne;
    public GameObject numPlatafTwo;

    //Variable estatica en la cual se definira la direccion de la plataforma 
    public static int randomDirection;

    //Variable que definira cual plataforma aparecera 
    private int randomPlataform;

    //Variables en las cuales se dara la posicion de la plataforma 
    public float vX;
    public float vY;


    private void Start()
    {
        
        for (int x = 0; x < PLataformsInX; x++)
        {
            vY = -3f;
            for (int y = 0; y < PlataformsInY; y++)
            {
                //Variables las cuales optienen un valor aleatorio entre 0 y 1
                randomPlataform = Random.Range(0, 2);
                randomDirection = Random.Range(0, 2);

                if (randomPlataform == 0)
                {
                    //Se instancia la plataforma la primer plataforma
                    GameObject go = GameObject.Instantiate(numPLatafOne) as GameObject;

                    //Se define la direccion en la cual se va a mover la plataforma y la posicion en la cual sera instanciada 
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
                    //Se instancia la segunda plataforma 
                    GameObject go = GameObject.Instantiate(numPlatafTwo) as GameObject;

                    //Se define la posicion en la cual se instanciara la plataforma 
                    Vector3 position = new Vector3(4f, vY, 0f);
                    vY += 1.2f;
                    go.transform.position = position;

                }



            }

        }
    }

 
   
    
}

