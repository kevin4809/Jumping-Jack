using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    //Array de prites donde iran los Corazones 
    public Sprite[] hearts;
  
    private void Start()
    {
      
    }

    private void Awake()
    {
        //Llamamos al metodo changelive y le decimos que "pos" es igual a el numero de vidas del jugador 
        ChangeLive(MoveCharapter.live);
    }


    //Metodo en el cual se controla los sprites de los corazones  
    public void ChangeLive ( int pos)
    {
        this.GetComponent<Image>().sprite = hearts[pos];
    }
}
