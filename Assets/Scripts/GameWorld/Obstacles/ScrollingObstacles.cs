using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingObstacles : MonoBehaviour
{
    public Image scrollingObstacle;
    public float rateOfScroll = 2.0f;

    private RectTransform RectObstacle;

    // Start is called before the first frame update
    void Start()
    {
        RectObstacle = scrollingObstacle.GetComponent<RectTransform>();
        StartCoroutine(ScrollMonster());
    }

    IEnumerator ScrollMonster()
    {
        while (true)
        {
            RectObstacle.position = new Vector2(RectObstacle.position.x - rateOfScroll, RectObstacle.position.y);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
