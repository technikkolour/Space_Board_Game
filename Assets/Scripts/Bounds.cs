using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When the ball hits the bounds, it has fallen off the playing screen and it is respawned.
    public void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Ball>().Spawn();
        other.GetComponent<Ball>().UpdateLives();
    }
}
