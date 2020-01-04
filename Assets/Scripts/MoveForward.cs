using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float moveDistance;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack3"))
        {
            transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);
        }
    }
}
