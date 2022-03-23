using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int runTime;
    public float timer;
    public float time_runTime;
    public Animator anim;
    public Quaternion quaternion;
    public float grade;
    public GameObject target;
    public bool attack;
    public RangeBoss rangeBoss;
    public float speed;
    public GameObject[] hit;
    public int hit_Select;

    public bool flamethrowerDown;
    public List<GameObject> pool = new List<GameObject>();
    public GameObject fire;
    public GameObject spawnShoot;
    public float timerShoot;

    public float areaPunch_distance;
    public bool direction_Skill;

    public GameObject ball_Energy;
    public GameObject point;
    public List<GameObject> pool2 = new List<GameObject>();

    public int fase = 1;
    public float HP_Min;
    public float HP_Max;
    public Image image;
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
        
    }

    public void Boss_Behavior()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < 12.5f)
        {
            Vector3 lookPos = transform.position - target.transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(target.transform.position);

            if(Vector3.Distance(transform.position,target.transform.position) > 1 && !attack)
            {
                switch (runTime)
                {
                    case 0:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        anim.SetBool("Walk", true);
                        anim.SetBool("Run", false);

                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        }

                        anim.SetBool("Attack", false);
                        timer += 1 * Time.deltaTime;

                        break;
                }
            }
        }
    }
}
