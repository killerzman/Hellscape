using TMPro;
using UnityEngine;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public bool isFlashing;
    public float flashTime = 0.5f;

    void Start()
    {
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (isFlashing)
        {
            myText.alpha = 0.0f;
            yield return new WaitForSeconds(flashTime);
            myText.alpha = 1.0f;
            yield return new WaitForSeconds(flashTime);
        }
    }
}
