using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoBoss : MonoBehaviour
{

    public Animator anim;
    public BossProvaScript boss;
    public GameObject target;
    public float melee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            melee = Random.Range(0, 4);
            switch (melee)
            {
                case 0:
                    anim.SetFloat("Skills", 0);
                    boss.hit_Select = 0;
                    break;
                case 1:
                    anim.SetFloat("Skills", 0.5f);
                    boss.hit_Select = 1;
                    break;
                case 2:
                    if(boss.fase == 2)
                    {
                        anim.SetFloat("Skills", 1f);
                    }
                    else
                    {
                        melee = 0;
                    }
                    break;
            }
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Attack", true);
            boss.attack = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
