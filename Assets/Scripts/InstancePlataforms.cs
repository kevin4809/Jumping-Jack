using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePlataforms : MonoBehaviour
{
    public int width;  
    public int height;

    public GameObject numPLatafOne;
    private GameObject[,] grid;
    public GameObject numPlatafTwo;

    private float[] valueX = new float[] { -20.5f, -16.5f, -12.5f };
    private float[] valueY = new float[] { -3f, -1f, 1f, 3f, 5f };

    public static int randomDirection;
   private int randomPlataform;
    public float vX;
    public float vY;


    private void Start()
    {
        InstancePLat();

    }

  

    public void InstancePLat()
    {
            grid = new GameObject[width, height];
            for (int x = 0; x < width; x++) 
            {
                vY = -3f;
                for (int y = 0; y < height; y++)
                {

                    randomPlataform = Random.Range(0, 2);
                    randomDirection = Random.Range(0, 2);
                    if (randomPlataform == 0)
                    {

                        GameObject go = GameObject.Instantiate(numPLatafOne) as GameObject;  

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
                        GameObject go = GameObject.Instantiate(numPlatafTwo) as GameObject; 

                        Vector3 position = new Vector3(4f, vY, 0f);
                        vY += 1.2f;
                        go.transform.position = position;

                    }

            

            }

            }

        }
    
}

