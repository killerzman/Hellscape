using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float time = 10f;
    public float bulletSpeed = 5.0f;
    public float bulletSpread = 30.0f;
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
            StartCoroutine(ShotgunHandler());
        }
    }

    IEnumerator ShotgunHandler()
    {
        while (enable)
        {
            gameObject.GetComponent<ImageOpacityChanger>().changeOpacity(255);
            if (Input.GetButtonDown("Shoot"))
            {
                GameObject[] bulletClone = new GameObject[2];
                for (int i = 0; i < bulletClone.Length; i++)
                {
                    bulletClone[i] = Instantiate(bullet, new Vector2( transform.position.x, transform.position.y + i * (i / 2 < bulletClone.Length / 2 ? -bulletSpread : bulletSpread) ), transform.rotation);
                    bulletClone[i].GetComponent<ShotgunBullet>().bulletSpeed = bulletSpeed;
                    bulletClone[i].SetActive(true);
                    bulletClone[i].transform.SetParent(bullet.transform.parent);
                }
            }

            time -= iterationInSeconds;
            if (time < 0)
            {
                enable = false;
            }
            yield return new WaitForSeconds(iterationInSeconds);
        }
        startedOnce = false;
        if (time < 0)
        {
            gameObject.GetComponent<ImageOpacityChanger>().changeOpacity(0);
        }
    }
}
