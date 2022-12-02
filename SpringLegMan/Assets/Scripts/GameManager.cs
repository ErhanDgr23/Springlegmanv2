using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject startPanel, winPanel, failPanel;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        failPanel.SetActive(true);
    }
     public void RestartGame()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     
    }
}
