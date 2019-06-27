using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public float bulletSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + bulletSpeed, gameObject.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle-Monster"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
