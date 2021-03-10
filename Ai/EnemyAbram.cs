using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAbram : MonoBehaviour
{
    public TankID enemyAbram;

    //Float values(visionRange is vision range of enemy,attackRange is enemy attakc range)
    public float visionRange, attackRange;
    float cooldown;

    //Int value
    public int explode = 0;

    //GameObjects
    public GameObject bullet,bulletSpwn;
    public GameObject particle,muzzleFlash;
    public GameObject img;
    public GameObject hud;
    public GameObject cannon;

    //Component
    Transform _bullet,target;
    NavMeshAgent agent;

    void Start()
    {
        //Navmesh agent setup.
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyAbram.spd;

        //Target setup.
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Particle setup
        particle.SetActive(false);

    }


    void Update()
    {
        //Check if Enemy is still alive.
        if(enemyAbram.hp >0)
        {
            //Float value for distance between Player and enemy.
            float distance = Vector3.Distance(target.position, transform.position);

            //If player is in enemy vision range.
            if (distance < visionRange && distance > attackRange)
            {
                agent.SetDestination(target.position);
            }
            //If player is in enemy attack range.
            else if (distance < visionRange && distance < attackRange)
            {
                agent.SetDestination(transform.position);
                cannon.transform.LookAt(target);

                //Enemy tank shooting palyer.
                if (Time.time > cooldown)
                {
                    ShootTarget();
                    cooldown = Time.time + enemyAbram.reloadSpd;
                }
            }
        }
        //If Enemy health is below 0.
        else if(enemyAbram.hp <=0)
        {
            EnemyDestroy();
            ChangeMat();
            if (explode == 0)
            {
                Instantiate(explosion.transform, spwner.transform.position, Quaternion.identity);
                cannon.SetActive(false);
                explode = 1;
            }
            else if (explode > 0)
            {
                agent.SetDestination(transform.position);
            }

        }
    }

    //Function control enemy shooting
    private void ShootTarget()
    {
        //Bullet Instantiate.
        _bullet = Instantiate(bullet.transform, bulletSpwn.transform.position, Quaternion.identity);
        _bullet.rotation = bulletSpwn.transform.rotation;

        //Muzzleflash Instantiate.
        _bullet = Instantiate(muzzleFlash.transform, bulletSpwn.transform.position, Quaternion.identity);
        _bullet.rotation = bulletSpwn.transform.rotation;
    }

    //Checking Collision of objects (bullet,missile)
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            int dam = other.GetComponent<Bullet>().damage;
            float damh = (dam/100f);
            enemyAbram.hp -= dam;
            Destroy(other.gameObject);
            img.GetComponent<Image>().fillAmount -= damh;
            //Debug.Log(damh);
        }

        else if(other.tag == "Missile")
        {
            int dam = other.GetComponent<Missile>().damage;
            float damh = (dam / 100f);
            enemyAbram.hp -= dam;
            Destroy(other.gameObject);
            img.GetComponent<Image>().fillAmount -= damh;
            Instantiate(explosion.transform, spwner.transform.position, Quaternion.identity);
        }
    }

    //Enemy destroyed.

    public GameObject spwner;
    public GameObject explosion;
    void EnemyDestroy()
    {
        particle.SetActive(true);
        hud.SetActive(false);
        cannon.SetActive(false);
        gameObject.tag = "Target";
    }

    //Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    //Change Material
    public Material des;
    public GameObject bod, can;
    
    void ChangeMat()
    {
        bod.GetComponent<Renderer>().material = des;
        can.GetComponent<Renderer>().material = des;
    }
}
