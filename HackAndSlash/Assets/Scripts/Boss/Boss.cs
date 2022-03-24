using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int runtime;
    public float timer;
    public Animator anim;
    public GameObject target;
    public Quaternion quaternion;
    public float grade;
    public bool attack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Behavior_Enemy();
    }

    public void Behavior_Enemy()
    {
        if(Vector3.Distance(transform.position,target.transform.position) > 5)
        {
            anim.SetBool("Run", false);
            timer += 1 * Time.deltaTime;
            if (timer >= 4)
            {
                runtime = Random.Range(0, 2);
                timer = 0;
            }
            switch (runtime)
            {
                case 0:
                    anim.SetBool("Walk", false);
                    break;
                case 1:
                    grade = Random.Range(0, 360);
                    quaternion = Quaternion.Euler(0, grade, 0);
                    runtime++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternion, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("Walk", true);
                    break;
            }

        }
        else
        {
            if(Vector3.Distance(transform.position,target.transform.position) > 1 && !attack)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                anim.SetBool("Attack", false);
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);

                anim.SetBool("Attack", true);
                attack = true;
            }
        }
    }

    public void FinaleAnimation()
    {
        anim.SetBool("Attack", false);
        attack = false;
    }
}
