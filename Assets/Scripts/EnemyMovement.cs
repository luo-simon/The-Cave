using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    [SerializeField]
    private bool hittingWall;
    [SerializeField]
    private bool notAtEdge;
    public Transform edgeCheck;
    private Animator anim;


    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge) // ||means or
        {
            moveRight = !moveRight;
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (moveRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        anim.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));

    }
}
