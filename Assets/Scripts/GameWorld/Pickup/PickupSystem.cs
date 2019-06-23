using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{

    public TextMeshProUGUI textToModify;

    GameObject score;
    private bool is2XActive = false;

    public void pickup2X()
    {
        //GameObject score = GameObject.FindGameObjectWithTag("Score");
        score = GameObject.FindGameObjectWithTag("Score");
        score.GetComponent<Score>().newMultiplier = 2;
        score.GetComponent<Score>().useNewMultiplier = true;
        is2XActive = true;
    }

    private void Update()
    {
        //Debug.Log("Pickup text updating");
        //Debug.Log(is2XActive);
        textToModify.text = "";

        if (is2XActive)
        {
            //GameObject score = GameObject.FindGameObjectWithTag("Score");
            if (score.GetComponent<Score>().tempSecondsForNewMultiplier >= 0.2f)
            {
                //Debug.Log("Updating 2x text");
                //THIS DOESN'T PROPERLY UPDATE YET
                textToModify.text += "2X: " + Mathf.RoundToInt(score.GetComponent<Score>().secondsForNewMultiplier) + "<br>";
            }
            else
            {
                is2XActive = false;
            }
        }
    }
}
