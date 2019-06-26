using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FINISH THIS!
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y);
    }
}
