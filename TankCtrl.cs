using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCtrl : MonoBehaviour
{
    public TankID Abram;

    //Values relate to tank movement.
    float speed;
    public float rotationSpeed;
    public float cannonRotationSpeed;

    //GameObjects
    public GameObject cannon; // Cannon mesh in prefab.
    public GameObject bullet; // Prefab of bullet.
    void Start()
    {
        speed = Abram.spd;
    }

    // Update is called once per frame
    void Update()
    {
        //Tank movement.
        if(Input.GetKey(KeyCode.W)) //Foward.
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S)) //Backward.
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        //Tank rotation.
        if(Input.GetKey(KeyCode.D)) //Rotate Left.
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A)) //Rotate Right.
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }

        //Cannon Rotation.
        if(Input.GetKey(KeyCode.Q)) //Cannon Rotate Left.
        {
            cannon.transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E)) //Cannon Rotate Right.
        {
            cannon.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    void ShotCannon()
    {

    }

    void TurretShot()
    {

    }
}
