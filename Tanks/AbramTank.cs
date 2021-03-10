using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbramTank : MonoBehaviour
{
    public TankID abram;

    //GameObjects
    public GameObject cannon; // Cannon mesh in prefab.
    public GameObject bullet; // Prefab of bullet.
    public GameObject bulletSpwn; // Bullet spawn point.
    public GameObject Muzzleflash;

    //Transform
    private Transform _bullet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Tank movement.
        if (Input.GetKey(KeyCode.W)) //Foward.
        {
            transform.Translate(Vector3.forward * abram.spd * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) //Backward.
        {
            transform.Translate(Vector3.back * abram.spd * Time.deltaTime);
        }
        //Tank rotation.
        if (Input.GetKey(KeyCode.D)) //Rotate Left.
        {
            transform.Rotate(Vector3.up * abram.rotaSpd * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A)) //Rotate Right.
        {
            transform.Rotate(Vector3.down * abram.rotaSpd * Time.deltaTime);
        }

        //Cannon Rotation.
        if (Input.GetKey(KeyCode.Q)) //Cannon Rotate Left.
        {
            cannon.transform.Rotate(Vector3.back * abram.canSpd * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E)) //Cannon Rotate Right.
        {
            cannon.transform.Rotate(Vector3.forward * abram.canSpd * Time.deltaTime);
        }

        //Shooting Canon
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (GetComponent<Hud>().txt.text == ("Ready"))
            {
                ShotCannon();
                GetComponent<Hud>().fillAmount = 0;
                GetComponent<Hud>().img.GetComponent<Image>().fillAmount = 0;
                GetComponent<Hud>().img.GetComponent<Image>().color = Color.red;
            }
        }
    }

    void ShotCannon()
    {
        //Bullet instantiate.
        _bullet = Instantiate(bullet.transform, bulletSpwn.transform.position, Quaternion.identity);
        _bullet.rotation = bulletSpwn.transform.rotation;

        //Muzzleflash instantiate.
        _bullet = Instantiate(Muzzleflash.transform, bulletSpwn.transform.position, Quaternion.identity);
        _bullet.rotation = bulletSpwn.transform.rotation;
    }

    void TurretShot()
    {

    }
}
