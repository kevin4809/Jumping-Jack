using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{   //Variable la cual sera igual a la posicion del fondo
    private Transform backGround;

    //Varible en la cual se almazenara la posicion del fondo en Z
    private float posBackGroundInZ;

    //Botones de play y exit
    public GameObject buttomPlay;
    public GameObject buttomExit;

    //texto que indica el nivel en la scena 
    public GameObject levelText;

    private void Start()
    {   //la variable background toma el componente transform del fondo 
        backGround = GameObject.Find("Background").GetComponent<Transform>();

        //El juego es colocado en pausa
        Time.timeScale = 0.0F;

        //el fodo se coloca en frente de todos los objetos en la scena 
        backGround.transform.position = new Vector3(0f, 1.03f, -5f);

    }

    //Metodo en el cual se controla las acciones de los botones 
    public void ActiveScene(string LoadGame)
    {
        switch (LoadGame)
        {
            case "Play":
                Time.timeScale = 1.0F;
                backGround.transform.position = new Vector3(0f, 1.03f, 1f);
                buttomPlay.gameObject.SetActive(false);
                buttomExit.gameObject.SetActive(false);
                levelText.gameObject.SetActive(false);

                break;

            case "Exit":
                Application.Quit();
                PlayerPrefs.DeleteAll();
                break;
        }

    }
}
