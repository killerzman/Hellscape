using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScrollingPickup : MonoBehaviour
{
    public Image scrollingPickup;
    public float rateOfScroll = 2.0f;

    private RectTransform RectPickup;

    // Start is called before the first frame update
    void Start()
    {
        RectPickup = scrollingPickup.GetComponent<RectTransform>();
        StartCoroutine(ScrollBackground());
    }

    IEnumerator ScrollBackground()
    {
        while (true)
        {
            RectPickup.position = new Vector2(RectPickup.position.x - rateOfScroll, RectPickup.position.y);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
