using TMPro;
using UnityEngine;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public float blinkTime = 0.5f;
    public bool isBlinking = true;

    private bool startedOnce = false;

    void Update()
    {
        if (!startedOnce)
        {
            startedOnce = true;
            StartCoroutine(BlinkText());
        }
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
