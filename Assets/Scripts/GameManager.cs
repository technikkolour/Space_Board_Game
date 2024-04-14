using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI field;
    public Button PeekButton;

    string MiniGameScene;

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

    public void UpdateFact(string FunFact, bool HasMinigame, string minigameName)
    {
        field.SetText(FunFact);
        if (HasMinigame)
        {
            PeekButton.gameObject.SetActive(true);
            MiniGameScene = minigameName;
        }
        else PeekButton.gameObject.SetActive(false);

    }

    public void TakeAPeek()
    {
        SceneManager.LoadScene(MiniGameScene);
    }

}
