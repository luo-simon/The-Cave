using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    //public float retreatDistance;

    private float attackCd; //time between attacks (attack cooldown)
    public float startAttackCd; //start time between attacks

    public GameObject projectile; //if ranged

    public Transform player;
    private Animator anim;
    Rigidbody2D rb;

    public bool inRange = false;
    public bool following = false;

    public Transform originalTransform;
    private Vector3 theScale;

    public bool originalSpriteFacingRight;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        attackCd = startAttackCd;

        theScale = originalTransform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (anim.GetBool("Attacking") == true) 
            anim.SetBool("Attacking", false);
        if(attackCd > 0)
            attackCd -= Time.deltaTime;


            if (following == true && GetComponent<EnemyHealthManager>().enemyHealth > 0 
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            Chase();
        }

        //FOR HEALTH BAR
        if(transform.localScale.x < 0)
        {
            //theScale.x *= -1;
            originalTransform.localScale = new Vector3 (theScale.x*-1, theScale.y, theScale.z);
        }
        if (transform.localScale.x > 0)
        {
            //theScale.x *= -1;
            originalTransform.localScale = new Vector3(theScale.x, theScale.y, theScale.z);
        }
    }

    public void Chase()
    {
        if (originalSpriteFacingRight)
        {
            if (rb.velocity.x > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else if (rb.velocity.x < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (!originalSpriteFacingRight)
        {
            if (rb.velocity.x > 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else if (rb.velocity.x < 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (transform.position.x - player.position.x - stoppingDistance > 0) //then move left
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else if (transform.position.x - player.position.x + stoppingDistance < 0) //then move right
            rb.velocity = new Vector2(speed, rb.velocity.y);

        //if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        //{
        //    inRange = false;
        //    //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); ** im using velocity instead
        //}
        //else if (Vector2.Distance(transform.position, player.position) < stoppingDistance) //&& Vector2.Distance(transform.position, player.position) > retreatDistance)
        //{
        //    inRange = true;
        //    rb.velocity = new Vector2(0, 0);
        //}

        //else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime)
        //}

        if (inRange == true)
        {
            if (attackCd <= 0)
            {
                anim.SetBool("Attacking", true);
                attackCd = startAttackCd;
            }
        }

    }

}
