using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthManager : MonoBehaviour {

    public int maxEnemyHealth;
    [Header("DO NOT EDIT ENEMYHEALTH, EDIT MAXENEMYHEALTH")]
    [Tooltip("DO NOT EDIT ENEMYHEALTH, EDIT MAXENEMYHEALTH")]
    public int enemyHealth;

    public GameObject deathEffect;
    public int pointsOnDeath;
    public float particleOffsetX;
    public float particleOffsetY;

    public float startHurtCooldown;
    [Header("DO NOT EDIT HURTCOOLDOWN, EDIT STARTHURTCOOLDOWN")]
    [Tooltip("DO NOT EDIT HURTCOOLDOWN, EDIT STARTHURTCOOLDOWN")]
    public float hurtCooldown;

    private SpriteRenderer rend;
    //private Color turnColour;
    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    public Material newMaterial;

    private Animator anim;
    public AnimationClip deathAnimation;

    public bool dead = false;

    // Use this for initialization
    void Start () {
        enemyHealth = maxEnemyHealth;
        hurtCooldown = startHurtCooldown;
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyHealth<= 0)
        {
            dead = true;
            if(deathEffect != null)
            {
                transform.position = new Vector3(transform.position.x + particleOffsetX, transform.position.y + particleOffsetY, transform.position.z);
                Instantiate(deathEffect, transform.position, transform.rotation);
                ScoreManager.AddPoints(pointsOnDeath);
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                if(deathAnimation != null)
                {
                    anim.Play(deathAnimation.name);
                    Destroy(gameObject, deathAnimation.length);
                }
                else
                    Destroy(gameObject);

                ScoreManager.AddPoints(pointsOnDeath);
            }

        }

        if (hurtCooldown > 0)
        {
            hurtCooldown -= Time.deltaTime;
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
        ScoreManager.AddPoints(pointsOnDeath);
    }

    public void GiveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
        Debug.Log("This enemy was damaged");
        rend.material = newMaterial;
        Invoke("ResetMaterial", 0.15f);
        //GetComponent<AudioSource>().Play(); //plays the audio attached to the enemy (NOT YET ATTACHED)
    }

    void ResetMaterial()
    {
        rend.material = defaultMaterial;
    }
}
