using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ball = GameObject.Find("ball");
        Ball ballScript = ball.GetComponent<Ball>();
        score = ballScript.score;
        scoreText.text = score.ToString();
    }

}
