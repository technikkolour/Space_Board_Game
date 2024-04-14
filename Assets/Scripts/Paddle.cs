using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    Rigidbody2D rBody;

    Vector3 mousePosition, mousePositionInWorld;
    Vector2 paddlePosition = new Vector2(0f, 0f);

    public float paddleSpeed = 10f;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Getting the current position of the mouse
        mousePosition = Input.mousePosition;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
	}

    void FixedUpdate()
    {
        paddlePosition = Vector2.Lerp(paddlePosition, mousePositionInWorld, paddleSpeed);
        rBody.MovePosition(paddlePosition);
    }

}
