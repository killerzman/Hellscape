using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadingInAndOutImage : MonoBehaviour
{
    public Image myImage;
    public float startAlpha = 1.0f;
    public float endAlpha = 0.4f;
    public float fadeTime = 1.5f;
    public bool isBlinking = true;

    private bool startedOnce = false;

    private void Update()
    {
        if (!startedOnce)
        {
            startedOnce = true;
            StartCoroutine(BlinkImage());
        }
    }

    IEnumerator BlinkImage()
    {
        while (isBlinking)
        {
            Color c = myImage.color;
            float maxAlpha = Mathf.Max(startAlpha, endAlpha);
            float minAlpha = Mathf.Min(startAlpha, endAlpha);
            for(float f = maxAlpha; f >= minAlpha; f -= Time.deltaTime / fadeTime)
            {
                c.a = f;
                myImage.color = c;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            for(float f = minAlpha; f <= maxAlpha; f += Time.deltaTime / fadeTime)
            {
                c.a = f;
                myImage.color = c;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        startedOnce = false;
        yield return null;
    }
}
