using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public Image scrollingBackground;
    public float rateOfScroll = 2.0f;

    private RectTransform RectBackground;

    // Start is called before the first frame update
    void Start()
    {
        RectBackground = scrollingBackground.GetComponent<RectTransform>();
        StartCoroutine(ScrollBackground());
    }

    IEnumerator ScrollBackground()
    {
        while (true)
        {
            RectBackground.position = new Vector2(RectBackground.position.x - rateOfScroll, RectBackground.position.y);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
