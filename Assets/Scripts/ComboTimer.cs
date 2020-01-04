using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTimer : StateMachineBehaviour {

    //public float comboWindowTime;
    //[SerializeField]
    //private float comboWindowTimeCounter;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //comboWindowTimeCounter = comboWindowTime;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    //if(comboWindowTimeCounter > 0)
        //{
        //    comboWindowTimeCounter -= Time.deltaTime;

            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("AdvanceCombo", true);
            }

        //}

        //else if(comboWindowTimeCounter <= 0)
        //{
        //}

	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("AdvanceCombo", false);
    }
}
