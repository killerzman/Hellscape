using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpMultiplier;
    public bool canDoubleJump = false;

    private Rigidbody2D rb;
    private bool isJumping;
    private int currentJumps;
    private int limitJumps;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        currentJumps = 0;
        limitJumps = 2;
    }

    void Update()
    {
        //Debug.Log(isJumping);
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, jumpMultiplier), ForceMode2D.Impulse);
        }

        if(isJumping)
        {
            if (!canDoubleJump)
            {
                if(rb.velocity.y == 0)
                {
                    isJumping = false;
                }
            }
            else
            {
                if(rb.velocity.y == 0)
                {
                    currentJumps = 0;
                    isJumping = false;
                }
                else
                {
                    if(currentJumps < limitJumps - 1)
                    {
                        isJumping = false;
                        currentJumps++;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup-2x"))
        {
            GameObject pickup = GameObject.FindGameObjectWithTag("Pickup-Wrapper");
            pickup.GetComponent<PickupSystem>().pickup2X();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Pickup-Pistol"))
        {
            GameObject pickup = GameObject.FindGameObjectWithTag("Pickup-Wrapper");
            pickup.GetComponent<PickupSystem>().pickupPistol();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Pickup-Shotgun"))
        {
            GameObject pickup = GameObject.FindGameObjectWithTag("Pickup-Wrapper");
            pickup.GetComponent<PickupSystem>().pickupShotgun();
            other.gameObject.SetActive(false);
        }
    }
}
