using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemys : MonoBehaviour
{
    //Velocidad a la cual se movera el enemigo
    public float speed;

    //Variables en las cuales se almazenara la posicion en Y y X de los enemigos
    private float actualPositionY;
    private float actualPositionX;

    private void Start()
    {
        //las variables son iguales a la poscion en Y, X y se le suma 1.2 unidades a la posicion Y 
        actualPositionY = transform.position.y;
        actualPositionX = transform.position.x;
        actualPositionY += 1.2f;
      
    }
    private void Update()
    {
        //Condicional en el cual se verifica que el enemigo al llegar a cierta posicion en X aparezca en el otro 
        //extremo de la pantalla Y 1.2 unidades mas arriba de donde estaba
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

        //Condicional en el cual se verifica que el enemigo al llegar a cierta posicion en Y aparezca de nuevo en la primera
        //plataforma de la parte de abajo del circuito 
        if (transform.position.y >= 4.5f)
        {
            actualPositionY = -2.645f;
        }

        //El enemigo se mueve 
        transform.Translate(Vector2.left * speed * Time.deltaTime);


    }

   
}
