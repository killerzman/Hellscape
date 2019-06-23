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
    public int originalMultiplier = 1;
    public int newMultiplier = 2;
    public float secondsForNewMultiplier = 10f;
    public bool useNewMultiplier = false;
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
            if (useNewMultiplier)
            {
                secondsForNewMultiplier -= secondsBetweenAdds;
                if (secondsForNewMultiplier >= 0)
                {
                    startScore += rateOfScore * newMultiplier;
                }
                else
                {
                    useNewMultiplier = false;
                }
            }
            else
            {
                startScore += rateOfScore * originalMultiplier;
            }
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
