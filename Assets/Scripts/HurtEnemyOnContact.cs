using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {


    public int damageToGive;

    private Animator anim;
    private EnemyHealthManager enemyHealthManager;

    //private float hurtCooldown; //time between which enemy can be knocked back
    //public float startHurtCooldown;

	// Use this for initialization
	void Start () {
        //hurtCooldown = startHurtCooldown;
	}
	
	// Update is called once per frame
	void Update () {

        //if (anim.GetBool("Hurt") == true)
        //{
        //    anim.SetBool("Hurt", false);
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Enemy")
        {
            anim = other.GetComponent<Animator>();
            enemyHealthManager = other.GetComponent<EnemyHealthManager>();
            enemyHealthManager.GiveDamage(damageToGive);

            if (enemyHealthManager.hurtCooldown <= 0)
            {
                anim.SetTrigger("Hurt");
                enemyHealthManager.hurtCooldown = enemyHealthManager.startHurtCooldown;
            }
            //else
            //{
            //    enemyHealthManager.hurtCooldown -= Time.deltaTime;
            //}


        }
    }
}
