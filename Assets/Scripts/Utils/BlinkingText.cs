using TMPro;
using UnityEngine;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public float blinkTime = 0.5f;
    public bool isBlinking = true;

    private bool startedOnce = false;

    public void Update()
    {
        startBlinking(isBlinking);
    }

    public void startBlinking(bool blinkState)
    {
        isBlinking = blinkState;
        if (!startedOnce)
        {
            startedOnce = true;
            StartCoroutine(BlinkText());
        }
    }

    public void stopBlinking()
    {
        isBlinking = false;
        startedOnce = false;
        startBlinking(isBlinking);
    }

    IEnumerator BlinkText()
    {
        while (isBlinking)
        {
            myText.alpha = 0.0f;
            yield return new WaitForSeconds(blinkTime);
            myText.alpha = 1.0f;
            yield return new WaitForSeconds(blinkTime);
        }
        startedOnce = false;
    }
}
