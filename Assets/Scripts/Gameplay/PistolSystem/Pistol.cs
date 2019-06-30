using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float time = 10f;
    public float bulletSpeed = 15.0f;
    public bool enable = false;
    public float iterationInSeconds = 0.01f;
    public GameObject bullet;

    private bool startedOnce = false;

    private void Awake()
    {
        gameObject.GetComponent<ImageOpacityChanger>().changeOpacity(0);
    }

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
            gameObject.GetComponent<ImageOpacityChanger>().changeOpacity(255);
            if (Input.GetButtonDown("Shoot"))
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, transform.position, transform.rotation);
                bulletClone.GetComponent<PistolBullet>().bulletSpeed = bulletSpeed;
                bulletClone.SetActive(true);
                bulletClone.transform.SetParent(bullet.transform.parent);
            }

            time -= iterationInSeconds;
            if(time < 0)
            {
                enable = false;
            }
            yield return new WaitForSeconds(iterationInSeconds);
        }
        startedOnce = false;
        if(time < 0)
        {
            gameObject.GetComponent<ImageOpacityChanger>().changeOpacity(0);
        }
    }
}
