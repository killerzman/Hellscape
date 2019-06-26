using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float time = 10f;
    public bool enable = false;
    public float iterationInSeconds = 0.01f;
    public GameObject bullet;

    private bool startedOnce = false;

    private void Update()
    {
        if (!startedOnce)
        {
            startedOnce = true;
            StartCoroutine(PistolHandler());
        }
    }

    IEnumerator PistolHandler()
    {
        while (enable)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, transform.position, transform.rotation);
                bulletClone.SetActive(true);
                bulletClone.transform.parent = bullet.transform.parent;
            }

            time -= iterationInSeconds;
            if(time < 0)
            {
                enable = false;
            }
            yield return new WaitForSeconds(iterationInSeconds);
        }
        startedOnce = false;
    }
}
