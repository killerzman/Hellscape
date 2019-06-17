using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnim : MonoBehaviour
{
    public Image myImage;
    public Sprite[] mySprites;
    public float secondsBetweenFrames = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoAnim());
    }

    IEnumerator DoAnim()
    {
        for(int i = 0; i < mySprites.Length; i++)
        {
            //Debug.Log(i);
            myImage.sprite = mySprites[i];
            yield return new WaitForSeconds(secondsBetweenFrames);
        }
        for(int i = mySprites.Length - 2; i >= 1; i--)
        {
            //Debug.Log(i);
            myImage.sprite = mySprites[i];
            yield return new WaitForSeconds(secondsBetweenFrames);
        }
        StartCoroutine(DoAnim());
    }
}
