using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    GUIStyle mainStyle = new GUIStyle();
    bool playerWon = false;
    bool gameOver = false;
    bool gameStarted = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the sprite you want to detect
        if (collision.gameObject.CompareTag("Finish"))
        {
            // You can put your success code here
            // For example, you can set a variable to indicate success, load a new scene, etc.
            playerWon = true;

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // You can put your success code here
            // For example, you can set a variable to indicate success, load a new scene, etc.
            playerWon = false;
            gameOver = true;

        }
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                gameStarted = true;
            }
            return;
        }

        if (gameOver)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver = false;
                gameStarted = false;
                playerWon = false;
                RestartGame();
            }
        }

        if (playerWon)
        {
            gameOver = true;
            SpriteRenderer spriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }

        if (gameOver || playerWon)
        {
            EndGame();
        }

        mainStyle.fontSize = 72;
        mainStyle.alignment = TextAnchor.MiddleCenter;
        mainStyle.normal.textColor = Color.black;
    }

    void OnGUI()
    {
        if (playerWon)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 20, 200, 40), "Success, you have reached the spaceship!!", mainStyle);
            Debug.Log("GUI displayed");
        }
        else if (gameOver)
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 20, 200, 40), "Game Over!!", mainStyle);
    }

    void EndGame()
    {
        // Find the sprite's GameObject
        PlayerMovement spriteMovement = FindObjectOfType<PlayerMovement>();
        // Stop the sprite's movement
        spriteMovement?.StopMovement();

    }

    void RestartGame()
    {
        // Find the sprite's GameObject
        GameObject spriteObject = GameObject.FindWithTag("Player");

        if (spriteObject != null)
        {
            // Reset the sprite's position to the initial position
            PlayerMovement spriteMovement = FindObjectOfType<PlayerMovement>();
            if (spriteMovement != null)
            {
                spriteObject.transform.position = spriteMovement.initPosAstronaut;
            }
            spriteMovement.StartMovement();
        }
        spriteObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}