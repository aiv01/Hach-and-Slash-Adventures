using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProvaScript : MonoBehaviour
{
    public int runTime; //rutina
    public float timer; //cronometro
    public float time_RunTime; //time_rutinas
    public Animator anim;
    public Quaternion quaternion; //angulo
    public float grade; //grado
    public GameObject target;
    public bool attack;
    public RangoBoss rangoBoss;
    public float speed;
    public GameObject[] hit;
    public int hit_Select;

    public GameObject energy_ball;
    public GameObject pointShoot;
    public List<GameObject> pool = new List<GameObject>();

    public int fase = 1;
    public float HP_Min;
    public float HP_Max;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(HP_Min > 0)
        {
            BoossLive();
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Dead");
                dead = true;
            }
        }
    }

    public void Behavior_Boss()
    {
        if(Vector3.Distance(transform.position,target.transform.position) < 15)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            pointShoot.transform.LookAt(target.transform.position);

            if(Vector3.Distance(transform.position,target.transform.position) > 1 && !attack)
            {
                switch (runTime)
                {
                    case 0:
                        //WALK//
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        anim.SetBool("Walk", true);
                        anim.SetBool("Run", false);

                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        }

                        anim.SetBool("Attack", false);
                        timer += 1 * Time.deltaTime;
                        if(timer > time_RunTime)
                        {
                            runTime = Random.Range(0, 5);
                            timer = 0;
                        }
                        break;
                    case 1:
                        //RUN//
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        anim.SetBool("Walk", false);
                        anim.SetBool("Run", true);

                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        }
                        anim.SetBool("Attack", false);
                        break;
                    case 2:
                        if(fase == 1)
                        {
                            anim.SetBool("Walk", false);
                            anim.SetBool("Run", false);
                            anim.SetBool("Attack", true);
                            anim.SetFloat("Skills", 1);
                            rangoBoss.GetComponent<CapsuleCollider>().enabled = false;
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                        }
                        else
                        {
                            runTime = 0;
                            timer = 0;
                        }
                        break;
                }
            }
        }
    }

    public void Ending_Animation()
    {
        runTime = 0;
        anim.SetBool("Attack", false);
        attack = false;
        rangoBoss.GetComponent<CapsuleCollider>().enabled = true;
    }

    public void StartAttack()
    {
        hit[hit_Select].GetComponent<SphereCollider>().enabled = true;
    }
    public void EndAttack()
    {
        hit[hit_Select].GetComponent<SphereCollider>().enabled = false;
    }

    public GameObject Get_Energy_Sphere()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(energy_ball, pointShoot.transform.position, pointShoot.transform.rotation) as GameObject;
        pool.Add(obj);
        return obj;
    }

    public void ActivateShield()
    {
        GameObject obj = Get_Energy_Sphere();
        obj.transform.position = pointShoot.transform.position;
        obj.transform.rotation = pointShoot.transform.rotation;
    }

    public void BoossLive()
    {
        if (HP_Min < 500)
        {
            fase = 2;
            time_RunTime = 1;
        }

        Behavior_Boss();
    }

}
