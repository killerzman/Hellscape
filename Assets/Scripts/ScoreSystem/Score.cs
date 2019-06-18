using System.Collections;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI myScore;
    public bool addToScore = true;
    public int startScore = 0;
    public int rateOfScore = 10;
    public float secondsBetweenAdds = 0.2f;
    public int multiplier = 1;
    public int howManyLeadingZeros = 6;

    private bool startedOnce = false;

    void Update()
    {
        if (!startedOnce)
        {
            startedOnce = true;
            StartCoroutine(AddScore());
        }
    }

    IEnumerator AddScore()
    {
        while (addToScore)
        {
            myScore.text = "";
            startScore += rateOfScore * multiplier;
            for(int i = startScore.ToString().Length; i < howManyLeadingZeros; i++)
            {
                myScore.text += '0';
            }
            myScore.text += startScore.ToString();
            yield return new WaitForSeconds(secondsBetweenAdds);
        }
        startedOnce = false;
    }
}
