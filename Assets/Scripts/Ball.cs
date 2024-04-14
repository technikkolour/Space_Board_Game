using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public Rigidbody2D rBody;
    public float ballSpeed = 100f;

    public static int lives = 3;
    public GameObject life1, life2, life3;

    public int score;
    public int bricksRemaining;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        Invoke("Spawn", 2);
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            InitialiseLives();
        }
    }
	
	// Update is called once per frame
	void Update () {
        /* Sometimes the ball can be hit with a force that makes it speed up massively during the game. In order to ensure that that
         * does not happen, we get the two coordinates of the velocity and we check whether the absolute value of either of them is 
         * larger than the speed that we have assigned the ball.
         * If it is, then the value is capped at the value of the speed (negative or positive, depending on the coordinate's sign).
         */
        float x, y;

        if (rBody.velocity.x > ballSpeed)
        {
            y = rBody.velocity.y;
            x = ballSpeed;
            rBody.velocity = new Vector2(x, y);
        } else if (rBody.velocity.x < ((-1) * ballSpeed))
        {
            y = rBody.velocity.y;
            x = (-1) * ballSpeed;
            rBody.velocity = new Vector2(x, y);
        } else if (rBody.velocity.y > ballSpeed)
        {
            x = rBody.velocity.x;
            y = ballSpeed;
            rBody.velocity = new Vector2(x, y);
        } else if (rBody.velocity.y < ((-1) * ballSpeed))
        {
            x = rBody.velocity.x;
            y = (-1) * ballSpeed;
            rBody.velocity = new Vector2(x, y);
        }

        /* In order to ensure that the ball does not slow down massively throughout the game, we check it's current velocity.
         * If the sum of the two coordinates is lower than 190, then the ball is slowing down too much and we give it a new velocity.
         */
        if ((Mathf.Abs(rBody.velocity.x) + Mathf.Abs(rBody.velocity.y)) < 190)
        {
            Vector2 newVelocity = rBody.velocity.normalized;
            newVelocity *= ballSpeed;
            rBody.velocity = newVelocity;
        }

        /* If hit with a lot of foce by the paddle, sometimes the ball can teleport outside of the playing field at high speed.
         * In order to check whether that has happened we get the ball's current position and save the coordinates as variables.
         * If the sum of the two coordinates is larger than 350, then it is outside the playing field and we have it respawn.
         */
        float ballPositionX = Mathf.Abs(rBody.position.x);
        float ballPositionY = Mathf.Abs(rBody.position.y);
        if ((ballPositionX + ballPositionY) > 350)
        {
            // If the ball falls outside of the playing field, the player loses a life.
            lives -= 1;
            Spawn();
        }

        // We update the lives counter at the top.
        CurrentLives();

        // When there are no breakable bricks left on the field, the next level is loaded.
        if (bricksRemaining==0)
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
            // FindObjectOfType<GameManager>().GameOver();
        }
    }

    // We use this function to spawn the ball at the centre of the playing field with a random velocity.
    public void Spawn () {
        transform.position = Vector3.zero;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rBody.velocity = new Vector2(ballSpeed * x, ballSpeed * y);
    }

    // This method updates the lives counter at the top of the screen depending on how many lives the player has left.
    public void CurrentLives()
    {

        if (lives == 3)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(true);
        }
        else if (lives == 2)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(false);
        }
        else if (lives == 1)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(false);
        }
        else if (lives == 0)
        {
            life1.gameObject.SetActive(false);
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void UpdateLives()
    {
        lives -= 1;
    }

    public void InitialiseLives()
    {
        lives = 3;
    }
}
