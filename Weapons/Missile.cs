using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody>();
    }

    //Values 
    public float time = 2;                 //(time,is how many second before it launch toward target.)
    public int damage;
    public bool fire;
    bool lockON = false;
    
    //Components
    public Transform target;
    Rigidbody rb;
    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            lockON = true;

            if (lockON == true)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
                rb.AddForce(0,-50, 0);
                //Debug.Log("LockOn");
            }
        }
        
        else if(time > 0)
        {
            rb.AddForce(0, 50, 0);
        }

       
    }
}
