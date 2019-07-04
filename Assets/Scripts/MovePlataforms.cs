using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataforms : MonoBehaviour
{
   
    public GameObject[] plataforms = new GameObject[8];
    public GameObject plataformsPrefab;
    private Vector2 plataformsPosition = new Vector2(0, -3.50f);
    void Start()
    {
        for(int i = 0; i<plataforms.Length; i++)
        {
            plataforms[i] = Instantiate(plataforms[0], plataformsPosition, Quaternion.identity);
        }
        
    }

    private void Update()
    {
        
    }
}
