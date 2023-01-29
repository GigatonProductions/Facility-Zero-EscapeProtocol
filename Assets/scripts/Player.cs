using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public Transform player;
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    [Space(10)]

    [Header("Camera")]
    public Transform camera;

    private bool isFacingRight = true;
    private bool isJumping = false;
    private Rigidbody2D rb;

    void Start()
    {
        //Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Fliping of the character model
        if (Input.GetKey(KeyCode.A) && isFacingRight) {
            flip();
        }
        if (Input.GetKey(KeyCode.D) && !isFacingRight) {
            flip();
        }

        //Jumping
        float horizontalMovement = Input.GetAxis("Horizontal");
        if (!isJumping)
        {
            rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
        }

        //Movement
        if (Input.GetKey(KeyCode.Space) && !isJumping) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        //Camera
        float cameraX = GetComponent<Transform>().transform.position.x;
        float cameraY = GetComponent<Transform>().transform.position.y;
        camera.transform.position = new Vector3(cameraX, cameraY+2.5f, camera.transform.position.z);
    }

    private void flip() {
        isFacingRight = !isFacingRight;

        Vector3 Scale = player.transform.localScale;
		Scale.z *= -1;
		player.transform.localScale = Scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
