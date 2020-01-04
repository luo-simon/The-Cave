using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    //public float maxSpeed = 10f;
    public float moveSpeed = 10f;
    public float jumpTakeOffSpeed = 7;

    bool grounded = false;

    bool facingRight = true;

    Animator anim;
    Rigidbody2D rb;

    float move = 0f;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = Input.GetAxis("Horizontal") * moveSpeed;
        anim.SetFloat("Speed", Mathf.Abs(move));

    }

    void FixedUpdate() {

        Vector2 velocity = rb.velocity;
        velocity.x = move;
        rb.velocity = velocity;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}
