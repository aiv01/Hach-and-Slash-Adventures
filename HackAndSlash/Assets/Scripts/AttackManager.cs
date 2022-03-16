using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    Animator animator;

    int noOfClicks;
    bool canClick;

    void Start()
    {
        animator = GetComponent<Animator>();
        noOfClicks = 0;
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ComboFight();
        }
    }

    void ComboFight()
    {
        if (canClick)
        {
            noOfClicks++;
        }
        if(noOfClicks == 1)
        {
            animator.SetInteger("AnimAttack", 21);
        }
    }

    public void ComboCheck()
    {
        canClick = false;

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Ellen_Combo2") && noOfClicks == 1)
        {
            animator.SetInteger("AnimAttack", 4);
            canClick = true;
            noOfClicks = 0;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ellen_Combo2") && noOfClicks >= 2)
        {
            animator.SetInteger("AnimAttack", 23);
            canClick = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ellen_Combo3") && noOfClicks == 2)
        {
            animator.SetInteger("AnimAttack", 4);
            canClick = true;
            noOfClicks = 0;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ellen_Combo3") && noOfClicks >= 3)
        {
            animator.SetInteger("AnimAttack", 6);
            canClick = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ellen_Combo4"))
        {
            animator.SetInteger("AnimAttack", 4);
            canClick = true;
            noOfClicks = 0;
        }

    }
}
