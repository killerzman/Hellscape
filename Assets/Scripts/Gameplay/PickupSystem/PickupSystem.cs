using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{

    public TextMeshProUGUI textToModify;

    GameObject score;
    GameObject p2X;
    private bool is2XActive = false;

    GameObject pistol;
    GameObject pPistol;
    private bool isPistolActive = false;

    GameObject shotgun;
    GameObject pShotgun;
    private bool isShotgunActive = false;

    public void pickup2X()
    {
        //GameObject score = GameObject.FindGameObjectWithTag("Score");
        score = GameObject.FindGameObjectWithTag("Score");
        p2X = GameObject.FindGameObjectWithTag("Pickup-2x");
        score.GetComponent<Score>().newMultiplier = p2X.GetComponent<Pickup2X>().multiplier;
        score.GetComponent<Score>().secondsForNewMultiplier = p2X.GetComponent<Pickup2X>().time;
        score.GetComponent<Score>().useNewMultiplier = true;
        is2XActive = true;
    }
    public void pickupPistol()
    {
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pPistol = GameObject.FindGameObjectWithTag("Pickup-Pistol");
        isPistolActive = true;
    }

    public void pickupShotgun()
    {
        shotgun = GameObject.FindGameObjectWithTag("Shotgun");
        pShotgun = GameObject.FindGameObjectWithTag("Pickup-Shotgun");
        isShotgunActive = true;
    }

    private void Update()
    {
        //Debug.Log("Pickup text updating");
        //Debug.Log(is2XActive);
        textToModify.text = "";

        if (is2XActive)
        {
            //GameObject score = GameObject.FindGameObjectWithTag("Score");
            if (score.GetComponent<Score>().secondsForNewMultiplier >= 0.0f)
            {
                //Debug.Log("Updating 2x text");
                textToModify.text += "2X: " + Mathf.RoundToInt(score.GetComponent<Score>().secondsForNewMultiplier) + "<br>";
            }
            else
            {
                is2XActive = false;
            }
        }

        if (isPistolActive)
        {
            if (true)
            {
                textToModify.text += "Pistol: " + "<br>";
            }
            else
            {
                isPistolActive = false;
            }
        }

        if (isShotgunActive)
        {
            if (true)
            {
                textToModify.text += "Shotgun: " + "<br>";
            }
            else
            {
                isShotgunActive = false;
            }
        }
    }
}
