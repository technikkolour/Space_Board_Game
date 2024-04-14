using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        int speed = 5;

        if (currentLevel == "SolarSystem")
        {
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (currentLevel == "Take Off")
        {
            if (Input.GetKey(KeyCode.Space))
                transform.Translate(Vector2.up * speed * 2 * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        gameManager.LoadNextScene();
    }
}
