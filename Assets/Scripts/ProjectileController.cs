using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    Rigidbody2D rb;

    public float speed;

    public PlayerController player;

    //public GameObject enemyDeathEffect;

    //public int pointsForKill;

    public GameObject impactEffect;

    public int damageToGive;

    public AudioClip impactSound;

   


	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        if(player.transform.localScale.x < 0) //if he is facing left then the speed is negative
        {
            speed = -speed;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
            //ScoreManager.AddPoints(pointsForKill);

            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
        }

        AudioSource.PlayClipAtPoint(impactSound, transform.position);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject); 
      
    }
}
