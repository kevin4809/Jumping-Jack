using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemys : MonoBehaviour
{
    public float speed;

    private float actualPositionY;
    private float actualPositionX;


   

    private void Start()
    {
        actualPositionY = transform.position.y;
        actualPositionX = transform.position.x;
        actualPositionY += 1.2f;
      

    }
    private void Update()
    {
        if (transform.position.x <= -6.809f)
        {
            transform.position = new Vector3(6.74f, actualPositionY, 0f);
            actualPositionY += 1.2f;

        }
        else
        {
            if (transform.position.x >= 18.50f)
            {
                transform.position = new Vector3(-0f, -actualPositionY, 0f);
                actualPositionY += 1.2f;
            }
        }


        if (transform.position.y >= 4.5f)
        {
            actualPositionY = -2.645f;
        }


        transform.Translate(Vector2.left * speed * Time.deltaTime);


    }

   
}
