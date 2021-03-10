using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileLauncher : MonoBehaviour
{
    //GameObjects
    public GameObject missile,spwnA,spwnB,spwnC;
    public GameObject etarget;
    //Component
    Transform _missile;

    //Float
    public float time;

    //Bool
    public bool fire = false;

    //Int
    int missileNum = 3;

    //Component
    public Transform target;

    //UI
    public Text num;

    void Start()
    {
        num.text = missileNum.ToString();
    }
    void Update()
    {
        etarget = GameObject.FindGameObjectWithTag("Enemy");
        //Declare enemy target's transform
        if(etarget == null)
        {
            target = null;
        }

        else if(etarget !=null)
        {
            target = etarget.transform;

            //Float value for distance in missile range.
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance < range)
            {
                if(missileNum >0)
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _missile = Instantiate(missile.transform, spwnA.transform.position, Quaternion.identity);
                    _missile.rotation = spwnA.transform.rotation;

                    missileNum -= 1;
                    num.text = missileNum.ToString();
                }
            }
        }
    }

    //Gizmo
    public float range;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
