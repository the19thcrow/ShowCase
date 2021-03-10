using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed,alive;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        alive -= Time.deltaTime;
        if(alive < 0)
        {
            Destroy(this.gameObject);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Building")
        {
            Instantiate(explosion.transform, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (other.tag == "Enemy")
        {
            Instantiate(explosion.transform, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
