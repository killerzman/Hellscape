using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{

    public TextMeshProUGUI textToModify;

    Score score;
    Pickup2X p2X;
    private bool is2XActive = false;

    Pistol pistol;
    PickupPistol pPistol;
    private bool isPistolActive = false;

    Shotgun shotgun;
    PickupShotgun pShotgun;
    private bool isShotgunActive = false;

    PlayerController player;

    public void pickup2X()
    {
        //GameObject score = GameObject.FindGameObjectWithTag("Score");
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        p2X = GameObject.FindGameObjectWithTag("Pickup-2x").GetComponent<Pickup2X>();
        score.newMultiplier = p2X.multiplier;
        score.secondsForNewMultiplier = p2X.time;
        score.useNewMultiplier = true;
        is2XActive = true;
    }
    public void pickupPistol()
    {
        pistol = GameObject.FindGameObjectWithTag("Pistol").GetComponent<Pistol>();
        pPistol = GameObject.FindGameObjectWithTag("Pickup-Pistol").GetComponent<PickupPistol>();
        pistol.time = pPistol.time;
        pistol.bulletSpeed = pPistol.bulletSpeed;
        pistol.enable = true;
        isPistolActive = true;
    }

    public void pickupShotgun()
    {
        shotgun = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<Shotgun>();
        pShotgun = GameObject.FindGameObjectWithTag("Pickup-Shotgun").GetComponent<PickupShotgun>();
        shotgun.time = pShotgun.time;
        shotgun.bulletSpeed = pShotgun.bulletSpeed;
        shotgun.bulletSpread = pShotgun.bulletSpread;
        shotgun.enable = true;
        isShotgunActive = true;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        //Debug.Log("Pickup text updating");
        //Debug.Log(is2XActive);
        textToModify.text = "";

        if (is2XActive)
        {
            //GameObject score = GameObject.FindGameObjectWithTag("Score");
            if (score.secondsForNewMultiplier >= 0.0f)
            {
                //Debug.Log("Updating 2x text");
                textToModify.text += "2X: " + Mathf.RoundToInt(score.secondsForNewMultiplier) + "<br>";
            }
            else
            {
                is2XActive = false;
            }
        }

        if (isPistolActive)
        {
            if (pistol.time >= 0.0f)
            {
                textToModify.text += "Pistol: " + Mathf.RoundToInt(pistol.time) + "<br>";
            }
            else
            {
                isPistolActive = false;
                player.isGunnedUp = false;
            }
        }

        if (isShotgunActive)
        {
            if (shotgun.time >= 0.0f)
            {
                textToModify.text += "Shotgun: " + Mathf.RoundToInt(shotgun.time) + "<br>";
            }
            else
            {
                isShotgunActive = false;
                player.isGunnedUp = false;
            }
        }
    }
}
