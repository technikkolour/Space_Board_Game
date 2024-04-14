using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Take Off");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        string currentLevel;
        currentLevel = SceneManager.GetActiveScene().name;

        if (currentLevel == "Take Off" || currentLevel == "Maze" || currentLevel == "SolarSystem")
        {
            SceneManager.LoadScene("SolarSystem");
        }
    }
}
