using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerPlataforms : MonoBehaviour
{
    public float speed;

    private float actualPositionY;
    private float actualPositionX;

    private float resetPlataform;
    public float timeForResetPlataform;

    private bool isLeft;

    private void Awake()
    {
        if (InstancePlataforms.randomDirection == 0) { isLeft = true; } else { isLeft = false; }
    }
    private void Start()
    {
        actualPositionY = transform.position.y;
        actualPositionX = transform.position.x;
       
    }

    
    private void Update()
    {
        
        resetPlataform -= Time.deltaTime;

        if(resetPlataform <= 0) 
        {
            transform.position = new Vector3(actualPositionX, actualPositionY, 0f);
            actualPositionY += 1.2f;
            resetPlataform = timeForResetPlataform;
        }


       /*if(transform.position.x <= -18.50f)
        {
            transform.position = new Vector3(0f,actualPosition, 0f);
            actualPosition += 2;
        }
        else
        {
            if(transform.position.x>= 18.50f)
            {
                transform.position = new Vector3(-0f, -actualPosition, 0f);
                actualPosition += 2;
            }
        }*/

        if (transform.position.y >= 4.5f)
        {
            actualPositionY = -3f;
        }

        if(isLeft == true) { transform.Translate(Vector2.left * speed * Time.deltaTime); }
        if(isLeft == false) { transform.Translate(Vector2.right * speed * Time.deltaTime); }
        

    }
}
