using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    //UI
    public GameObject img;
    public Text txt;

    //Value
    public float fillAmount;
    void Start()
    {
        fillAmount = img.GetComponent<Image>().fillAmount;
        img.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (fillAmount < 1)
        {
            img.GetComponent<Image>().fillAmount += GetComponent<AbramTank>().abram.reloadSpd;
            fillAmount += GetComponent<AbramTank>().abram.reloadSpd;
            txt.text = "Reloading";
        }
        if (fillAmount > 1)
        {
            txt.text = "Ready";
            img.GetComponent<Image>().color = Color.green;
            img.GetComponent<Image>().fillAmount = 1;
        }
    }
}
