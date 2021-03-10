using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    public float aliveTime;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;
        
        if(aliveTime < 0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
