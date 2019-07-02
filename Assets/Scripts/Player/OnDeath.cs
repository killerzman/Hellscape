using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    static GameObject DeathPanel;

    private void Start()
    {
        DeathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        hide();
    }

    public static void hide()
    {
        DeathPanel.transform.Find("DeathPanelString").GetComponent<TMProOpacityChanger>().changeOpacity(0);
        DeathPanel.transform.Find("DeathPanelSound").GetComponent<AudioSource>().playOnAwake = false;
    }

    public static void show()
    {
        DeathPanel.transform.Find("DeathPanelString").GetComponent<TMProOpacityChanger>().changeOpacity(255);
        DeathPanel.transform.Find("DeathPanelSound").GetComponent<AudioSource>().Play();
    }
}
