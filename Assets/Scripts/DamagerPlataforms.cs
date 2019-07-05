using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerPlataforms : MonoBehaviour
{
    public float speed; // Velocidad a la cual se va a mover la plataforma

    //Floats en los cuales se almazenara la posicion de la plataforma en Y y en X
    private float actualPositionY; 
    private float actualPositionX; 

    //Contador con el cual se controlara el cambio de posicion de las plataformas  
    private float resetPlataform;
    public float timeForResetPlataform;

    // Boleano con el cual se controlara la direccion en la cual se movera la plataforma 
    private bool isLeft;

    private void Awake()
    {
        //le asignamos una direccion a la plataforma 
        if (InstancePlataforms.randomDirection == 0) { isLeft = true; } else { isLeft = false; }
    }
    private void Start()
    {
        //las variables de tipo float seran iguales a la posicion en Y y X De la plataforma 
        actualPositionY = transform.position.y;
        actualPositionX = transform.position.x;
       
    }

    
    private void Update()
    {
        //El valor de resetplatafor se restara a medida que pasa el tiempo
        resetPlataform -= Time.deltaTime;

        //Cuando resetPlataform sea menor o igual a 0 la plataforma subira 1.2 unidades
        if(resetPlataform <= 0) 
        {
            transform.position = new Vector3(actualPositionX, actualPositionY, 0f);
            actualPositionY += 1.2f;
            resetPlataform = timeForResetPlataform;
        }

        //Cuando la plataforma sobrepase las 4.5 unidades sera regresada a la posicion -3 
        if (transform.position.y >= 4.5f)
        {
            actualPositionY = -3f;
        }

        //Se mueven las plataformas
        if(isLeft == true) { transform.Translate(Vector2.left * speed * Time.deltaTime); }
        if(isLeft == false) { transform.Translate(Vector2.right * speed * Time.deltaTime); }
        

    }
}
