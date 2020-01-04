using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    private Animator anim;

    public Rigidbody2D rb;

    public GameObject boss;

    public float moveSpeed;

    public Transform currentPoint;

    public Transform[] points;

    public int pointSelection;

    public Transform firePoint;
    public GameObject projectile;
    public float moveDelay;
    public float moveDelayCounter;


    public float shotDelay;
    public float shotDelayCounter;

    

	// Use this for initialization
	void Start () {
        currentPoint = points[pointSelection];
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        boss.transform.position = Vector3.MoveTowards(boss.transform.position, currentPoint.position, Time.deltaTime*moveSpeed); //start, end, speed /fra me


        if (boss.transform.position == currentPoint.position)
        {
            moveDelayCounter -= Time.deltaTime;
            if(pointSelection == 1)
                transform.localScale = new Vector3(-1f, 1f, 1f);

            if (pointSelection == 0)
                transform.localScale = new Vector3(1f, 1f, 1f);

            shotDelayCounter -= Time.deltaTime;
            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(projectile, firePoint.position, firePoint.rotation);
                anim.SetBool("Attacking", true);
            }

            

            if (moveDelayCounter <= 0)
            {
                anim.SetBool("Attacking", false);

                moveDelayCounter = moveDelay;

                pointSelection++;

                if(pointSelection == points.Length)
                    pointSelection = 0;

                currentPoint = points[pointSelection];
            }
        }

    }
}
