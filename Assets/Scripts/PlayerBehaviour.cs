using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 5;

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
