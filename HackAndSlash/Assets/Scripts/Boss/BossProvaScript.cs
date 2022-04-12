using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossProvaScript : MonoBehaviour
{
    public int runTime; 
    public float timer; 
    public float time_RunTime;
    public Animator anim;
    public Quaternion quaternion;
    public float grade;
    public GameObject target;
    public bool attack;
    public RangoBoss rangoBoss;
    public float speed;
    public GameObject[] hit;
    public int hit_Select;
    [SerializeField] private CharacterStats stats;

    public GameObject pointShoot;
    private BulletManager bm;
    [SerializeField] private float shootSpeed;

    public int fase = 1;
    private float HP_Min;
    private float HP_Max;
    public Image HP_bar;
    public GameObject HP_Boss;
    public AudioSource audioBoss;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        HP_Max = stats.MaxHp;
        HP_Min = HP_Max;
    }

    private void Awake() {
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
    }
    // Update is called once per frame
    void Update()
    {
        HP_Min = stats.hp;
        HP_bar.fillAmount = HP_Min / HP_Max;
        if (HP_Min > 0)
        {
            BoossLive();
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Dead");
                audioBoss.enabled = false;
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
            audioBoss.enabled = true;
            HP_Boss.SetActive(true);

            if (Vector3.Distance(transform.position,target.transform.position) > 2 && !attack)
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
                            runTime = Random.Range(0, 2);
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
                        //ENERGYSHOOT
                        if(fase == 2)
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
        hit[hit_Select].GetComponent<BoxCollider>().enabled = true;
    }
    public void EndAttack()
    {
        hit[hit_Select].GetComponent<BoxCollider>().enabled = false;
    }


    public void ActivateShield()
    {
        Projectile instance = bm.GetBullet(ProjectileType.boss);
        instance.transform.position = pointShoot.transform.position;
        instance.gameObject.SetActive(true);
        instance.Shoot(stats, transform.forward, shootSpeed);
    }

    public void BoossLive()
    {
        if (HP_Min < HP_Max * 0.5f)
        {
            fase = 2;
            time_RunTime = 1;
        }

        Behavior_Boss();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 15);
    }

    private void OnDisable()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
