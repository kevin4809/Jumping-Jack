using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    private Transform backGround;
    private float posBackGroundInZ;

    public GameObject buttomPlay;
    public GameObject buttomExit;
    public GameObject levelText;

    private void Start()
    {
        backGround = GameObject.Find("Background").GetComponent<Transform>();
        Time.timeScale = 0.0F;
        backGround.transform.position = new Vector3(0f, 1.03f, -5f);

    }

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
