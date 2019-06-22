using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnim : MonoBehaviour
{
    public Image myImage;
    public Sprite[] mySprites;
    public float secondsBetweenFrames = 0.3f;
    //public bool pauseAnimation = false;
    public bool repeatInReverse = false;
    public bool reversed = false;

    private bool hasBeenReversed = false;



    // Start is called before the first frame update
    void Start()
    {
        updateAnim();
        StartCoroutine(DoAnim());
    }

    void updateAnim()
    {
        if ((reversed && !hasBeenReversed) || (!reversed && hasBeenReversed))
        {
            hasBeenReversed = !hasBeenReversed;
            Sprite[] _revSprites = mySprites;
            for (int i = 0; i < mySprites.Length; i++)
            {
                _revSprites[i] = mySprites[mySprites.Length - 1 - i];
            }
            mySprites = _revSprites;
        }
    }

    IEnumerator DoAnim()
    {

        for (int i = 0; i < mySprites.Length; i++)
        {
            //Debug.Log(i);
            myImage.sprite = mySprites[i];
            updateAnim();
            yield return new WaitForSeconds(secondsBetweenFrames);
        }
        if (repeatInReverse)
        {
            for (int i = mySprites.Length - 2; i >= 1; i--)
            {
                //Debug.Log(i);
                myImage.sprite = mySprites[i];
                updateAnim();
                yield return new WaitForSeconds(secondsBetweenFrames);
            }
        }
        
        updateAnim();
        StartCoroutine(DoAnim());
    }
}
