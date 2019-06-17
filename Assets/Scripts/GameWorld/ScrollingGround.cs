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

    private Rect screenRect;
    private RectTransform Ground1;
    private RectTransform Ground2;
    private int nextAsset = 1;

    // Start is called before the first frame update
    void Start()
    {
        scrollingGround1.sprite = myScrollingAssets[0];
        scrollingGround2.sprite = myScrollingAssets[1];
        Ground1 = scrollingGround1.GetComponent<RectTransform>();
        Ground2 = scrollingGround2.GetComponent<RectTransform>();
        StartCoroutine(ScrollGround());
    }

    // Update is called once per frame
    IEnumerator ScrollGround()
    {
        for(float xPos1 = Ground1.position.x; xPos1 >= -Screen.width/2; xPos1 -= rateOfScroll)
        {
            Ground1.position = new Vector2(xPos1, Ground1.position.y);
            Ground2.position = new Vector2(xPos1 + Screen.width, Ground2.position.y);
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
        Ground1.position = new Vector2(Screen.width, Ground1.position.y);

        for(float xPos2 = Ground2.position.x; xPos2 >= -Screen.width/2; xPos2 -= rateOfScroll)
        {
            Ground2.position = new Vector2(xPos2, Ground2.position.y);
            Ground1.position = new Vector2(xPos2 + Screen.width, Ground1.position.y);
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

        Ground2.position = new Vector2(Screen.width, Ground2.position.y);
        StartCoroutine(ScrollGround());
    }
}
