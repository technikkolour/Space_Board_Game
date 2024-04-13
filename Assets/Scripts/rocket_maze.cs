using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation.Normalize();
        Move();
    }

    public void Move()
    {
        
            int speed = 100;

            if (Input.GetKeyDown(KeyCode.RightArrow))
                transform.Translate(Vector2.right * speed *2* Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                transform.Translate(Vector2.left * speed * 2 * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                transform.Translate(Vector2.up * speed * 2 * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                transform.Translate(Vector2.down * speed * 2 * Time.deltaTime);
           

    }
        
}