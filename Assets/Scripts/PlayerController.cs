using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    [SerializeField]
    private bool grounded;

    public bool doubleJumped;

    private Animator anim; //creates variabla anim as an empty Animator object

    public Transform firePoint;
    public GameObject projectile;
    public float shotDelay;
    public float shotDelayCounter;
    public Image spellCooldownIcon;
    public TextMeshProUGUI spellCooldownText;

    public bool haveSword;
    public bool haveSpell;
    public bool haveDash;
    public bool haveBow;

    public float knockback;
    public float knockbackCount;
    public float knockbackTime;
    public bool knockFromRight;

    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    public float dashCooldown;
    public float startDashCooldown;
    private bool dashing;
    public GameObject dashEffect;
    public Transform particlePos;
    public Image dashCooldownIcon;
    public TextMeshProUGUI dashCooldownText;

    public AudioClip jumpSound;
    public AudioClip fireSound;

    private bool facingRight = true;



    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>(); //gets the Animator component already assigned to player and assigns it to variable anim
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Grounded", grounded); //changes the parameter grounded 
    }

    // Update is called once per frame
    void Update() {                                //not the best movement code (very inefficient) but works for now <<< CHANGE LATER

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRespawn") 
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack") 
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack2") 
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack3") 
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("BowAttackStart")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("BowAttackHold")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("BowAttackRelease"))
        {
            Movement();
            if (dashCooldown <= 0)
                canDash();
            else
                dashCooldown -= Time.deltaTime;
        }
        else
            rb.velocity = new Vector2(0, 0);

        if (anim.GetBool("Casting") == true)
            anim.SetBool("Casting", false);

        if (haveSpell == true)
        {
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    Instantiate(projectile, firePoint.position, firePoint.rotation);
            //    AudioSource.PlayClipAtPoint(fireSound, transform.position);
            //    shotDelayCounter = shotDelay;
            //    anim.SetBool("Casting", true);
            //}
            if (Input.GetButtonDown("Fire2"))
            {   
                if (shotDelayCounter <= 0)
                {
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    AudioSource.PlayClipAtPoint(fireSound, transform.position);
                    anim.SetBool("Casting", true);
                    shotDelayCounter = shotDelay;
                }
            }
            if(shotDelayCounter >=0)
                shotDelayCounter -= Time.deltaTime;
        }

        if (anim.GetBool("Attacking") == true)
            anim.SetBool("Attacking", false);
        if (haveSword == true)
        {
            if (Input.GetButtonDown("Fire1"))
                anim.SetBool("Attacking", true);
        }

        if (haveBow == true && grounded)
        {
            if (Input.GetButton("Fire3"))
                anim.SetBool("bowHold", true);
            if (Input.GetButtonUp("Fire3"))
                anim.SetBool("bowHold", false);
        }

        int dashCooldownInt = Convert.ToInt32(dashCooldown);
        dashCooldownText.text = "" + dashCooldownInt;
        dashCooldownIcon.fillAmount = dashCooldown / startDashCooldown;

        int spellCooldownInt = Convert.ToInt32(shotDelayCounter);
        spellCooldownText.text = "" + spellCooldownInt;
        spellCooldownIcon.fillAmount = shotDelayCounter / shotDelay;

        //if (Input.GetKeyUp(KeyCode.Return))
        //{
        //GameObject swordHolder;
        //swordHolder = GameObject.FindGameObjectWithTag("Sword");
        //Destroy(swordHolder);
        //    StartCoroutine(Delay());
        //}
    }
    //public IEnumerator Delay()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    anim.SetBool("Attacking", false);
    //}

    public void Movement()
    {
        if (grounded)
        {
            doubleJumped = false;
        }

        if (anim.GetBool("DoubleJump") == true)
        {
            anim.SetBool("DoubleJump", false);
        }

        if (Input.GetButtonDown("Jump") && grounded) //GetKeyDown only triggers once when it is pressed
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            Jump(); //I made this into a function
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            Jump();
            doubleJumped = true;
            anim.SetBool("DoubleJump", true);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }

        //moveVelocity = 0f;

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        //Old movement code:
        //if (Input.GetKey(KeyCode.D))
        //{
        //    //rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        //    moveVelocity = moveSpeed;
        //}
        //
        //if (Input.GetKey(KeyCode.A))
        //{
        //    //rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        //    moveVelocity = -moveSpeed;
        //}

        if (knockbackCount <= 0)
        {
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y); //if there is no keys pressed, the move velocity is zero so the player will stop moving
            anim.SetBool("Hurt", false);
        }
        else
        {
            if (knockFromRight)
            {
                rb.velocity = new Vector2(-knockback, knockback);
                anim.SetBool("Hurt", true);
            }
            if (!knockFromRight)
            {
                rb.velocity = new Vector2(knockback, knockback);
                anim.SetBool("Hurt", true);
            }

            knockbackCount -= Time.deltaTime;


        }


        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); //sets the Speed parameter on the animator for the player to the velocity of the player
                                                          // Mathf.Abs converts removes negative sign (e.g. -5 goes to 5)
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);           //localScale is the size (e.g. if it is (2,2) then it will be twice as big on x and y axis
            facingRight = true;                                        //it means - if the player is moving right then the animation will be normal
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);  // flips the player if he is facing left
            facingRight = false;
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    public void canDash()
    {
        if (anim.GetBool("Sliding") == true)
        {
            anim.SetBool("Sliding", false);
        }

        if (!dashing && moveVelocity != 0 && haveDash)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                dashing = true;
            }
        }

        else if(dashing)
        {
            if (dashTime <= 0)
            {
                dashing = false;
                dashTime = startDashTime;
                dashCooldown = startDashCooldown;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if(dashing)
                {
                    Instantiate(dashEffect, particlePos.position, particlePos.rotation);
                    anim.SetBool("Sliding", true);
                    rb.velocity = new Vector2(rb.velocity.x * dashSpeed, rb.velocity.y);      
                }
            }
        }
    }
}
