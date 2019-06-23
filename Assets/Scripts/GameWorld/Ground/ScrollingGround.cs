using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingGround : MonoBehaviour
{
    public Image scrollingGround1;
    public Image scrollingGround2;
    public float rateOfScroll = 20.0f;
    public bool randomScrolling = true;
    public Sprite[] myScrollingAssets;

    //private Rect screenRect;
    private RectTransform RectGround1;
    private RectTransform RectGround2;
    private int nextAsset = 1;

    // Start is called before the first frame update
    void Start()
    {
        scrollingGround1.sprite = myScrollingAssets[0];
        scrollingGround2.sprite = myScrollingAssets[1];
        RectGround1 = scrollingGround1.GetComponent<RectTransform>();
        RectGround2 = scrollingGround2.GetComponent<RectTransform>();
        StartCoroutine(ScrollGround());
    }

    // Update is called once per frame
    IEnumerator ScrollGround()
    {
        for(float xPos1 = RectGround1.position.x; xPos1 >= -Screen.width/2; xPos1 -= rateOfScroll)
        {
            RectGround1.position = new Vector2(xPos1, RectGround1.position.y);
            RectGround2.position = new Vector2(xPos1 + Screen.width, RectGround2.position.y);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (randomScrolling)
        {
            scrollingGround1.sprite = myScrollingAssets[Random.Range(0, myScrollingAssets.Length)];
        }
        else
        {
            if(nextAsset + 1 > myScrollingAssets.Length - 1)
            {
                nextAsset = 0;
            }
            else
            {
                nextAsset++;
            }
            scrollingGround1.sprite = myScrollingAssets[nextAsset];
        }
        RectGround1.position = new Vector2(Screen.width, RectGround1.position.y);

        for(float xPos2 = RectGround2.position.x; xPos2 >= -Screen.width/2; xPos2 -= rateOfScroll)
        {
            RectGround2.position = new Vector2(xPos2, RectGround2.position.y);
            RectGround1.position = new Vector2(xPos2 + Screen.width, RectGround1.position.y);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (randomScrolling)
        {
            scrollingGround2.sprite = myScrollingAssets[Random.Range(0, myScrollingAssets.Length)];
        }
        else
        {
            if (nextAsset + 1 > myScrollingAssets.Length - 1)
            {
                nextAsset = 0;
            }
            else
            {
                nextAsset++;
            }
            scrollingGround2.sprite = myScrollingAssets[nextAsset];
        }

        RectGround2.position = new Vector2(Screen.width, RectGround2.position.y);
        StartCoroutine(ScrollGround());
    }
}
