using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

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
        SceneManager.LoadScene("Level1");
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            SceneManager.LoadScene("GameOver");
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Victory");
        // string currentLevel;
        // currentLevel = SceneManager.GetActiveScene().name;

        // if (currentLevel == "Level1")
        // {
        //     SceneManager.LoadScene("Level2");
        // }
        // else if (currentLevel == "Level2")
        // {
        //     SceneManager.LoadScene("Level3");
        // }
        // else if (currentLevel == "Level3")
        // {
        //     SceneManager.LoadScene("Victory");
        // }
    }
   

}
