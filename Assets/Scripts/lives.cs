using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public Sprite[] hearts;
  
    private void Start()
    {
        ChangeLive(MoveCharapter.live);
    }

   

    public void ChangeLive ( int pos)
    {
        this.GetComponent<Image>().sprite = hearts[pos];
    }
}
