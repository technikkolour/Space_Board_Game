using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 100.0f;
    public bool canMove = true;
    public Vector2 initPosAstronaut;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody2D>();
        initPosAstronaut = rb.position;
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // Input from arrow keys
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Movement calculation
            Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * 40 * Time.deltaTime;

            // Apply movement to Rigidbody
            rb.MovePosition(rb.position + (Vector2)movement);
        }
    }

    public void StopMovement()
    {
        canMove = false;
    }
    public void StartMovement()
    {
        canMove = true;

    }
}