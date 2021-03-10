using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    public GameObject mainCam;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCam.transform;
    }
    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
